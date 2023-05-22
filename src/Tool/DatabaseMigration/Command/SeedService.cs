using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entity;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Http;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Microsoft.Extensions.Options;
using File = Google.Apis.Drive.v3.Data.File;

namespace DatabaseMigration.Command;

public class SeedService : ISeedService, IDisposable
{
    private readonly IOptions<SeedServiceConfig> _config;
    private SheetsService? _sheetsService;
    private DriveService? _driveService;
    private bool _disposed;
    
    public SeedService(IOptions<SeedServiceConfig> config)
    {
        _config = config;
    }

    public async ValueTask CreateAsync(ICredential credential, string tableGroupName, string tableName)
    {
        if (string.IsNullOrEmpty(tableGroupName) || string.IsNullOrEmpty(tableName))
        {
            throw new ArgumentException("table group name and table name should not be empty.");
        }

        var entity = FindEntity(tableName);
        if (entity is null)
        {
            throw new ArgumentException($"Table {tableName} is not found.");
        }

        (_sheetsService, _driveService) = InitializeGoogleApis(credential);

        var file = await FindFileAsync(_config.Value.SpreadsheetFolderId, tableGroupName);
        var alreadyCreatedSpreadSheet = file is not null;

        string sheetTitle;
        string spreadsheetId;
        int sheetId;
        if (alreadyCreatedSpreadSheet)
        {
            var sheet = await FindSheetAsync(file!.Id, tableName);
            if (sheet is not null)
            {
                throw new ApplicationException($"Table {tableName} already exists in {tableGroupName}.");
            }

            var copiedSheetId = await CopySheetFromTemplateAsync(file.Id);
            if (copiedSheetId is null)
            {
                throw new ApplicationException($"Failed to copy sheet {tableName} from template.");
            }

            sheet = await FindSheetAsync(file.Id, copiedSheetId.Value);
            if (sheet is null)
            {
                throw new ApplicationException($"Failed to find sheet {tableName}.");
            }

            sheetTitle = sheet.Properties.Title;
            sheetId = sheet.Properties.SheetId!.Value;
            spreadsheetId = file.Id;
        }
        else
        {
            var createdSpreadsheet = await CopySpreadsheetFromTemplateAsync(tableGroupName);
            if (createdSpreadsheet is null)
            {
                throw new ApplicationException($"Failed to create spreadsheet {tableGroupName}.");
            }
            
            var sheet = await FindSheetAsync(createdSpreadsheet.Id, "Sheet");
            if (createdSpreadsheet is null)
            {
                throw new ApplicationException("Failed to find sheet.");
            }

            sheetTitle = sheet.Properties.Title;
            sheetId = sheet.Properties.SheetId!.Value;
            spreadsheetId = createdSpreadsheet.Id;
        }
        
    }

    public async ValueTask RenameLabelsAsync(GoogleCredential credential, string tableGroupName, string tableName, string[] labels,
        string newLabel)
    {
        if (string.IsNullOrEmpty(tableGroupName) || string.IsNullOrEmpty(tableName))
        {
            throw new ArgumentException("table group name and table name should not be empty.");
        }

        if (labels.Length is 0 || string.IsNullOrEmpty(newLabel))
        {
            throw new ArgumentException("labels and new label should not be empty.");
        }

        (_sheetsService, _) = InitializeGoogleApis(credential);

        var files = await FindFilesByFolderIdAsync(_config.Value.SpreadsheetFolderId);

        for (var i = 0; i < files.Count; i++)
        {
            var spreadsheetId = files[i].Id;
            var sheets = await FindSheetBySpreadsheetIdAsync(spreadsheetId);
            if (sheets is null)
            {
                continue;
            }

            var ranges = new List<string>(sheets.Count * 2); // 2 = label column and row
            foreach (var sheet in sheets)
            {
                ranges.AddRange(new []
                {
                    $"{sheet.Properties.Title}!{_config.Value.ColumnLabelStartCell}:{new SpreadsheetCell(sheet.Properties.GridProperties.ColumnCount!.Value, _config.Value.ColumnLabelStartCell.RowIndex)}",
                    $"{sheet.Properties.Title}!{_config.Value.RowLabelStartCell}:{new SpreadsheetCell(_config.Value.RowLabelStartCell.ColumnIndex, sheet.Properties.GridProperties.RowCount!.Value)}",
                });
            }
            
            var updateValueRanges = new List<ValueRange>();
            var valueRanges = await GetRangesAsync(spreadsheetId, ranges);

            if (valueRanges is null)
            {
                continue;
            }
            
            foreach (var valueRange in valueRanges)
            {
                if (valueRange.Values is null) continue;
                
                var modified = false;
                var values = new List<IList<object?>>(valueRange.Values);

                for (var v = 0; v < valueRange.Values.Count; v++)
                {
                    var row = valueRange.Values[v];
                    for (var j = 0; j < row.Count; j++)
                    {
                        var value = row[j];
                        if (value is null) continue;

                        if (!labels.Contains(value.ToString())) continue;

                        values[v][j] = newLabel;
                        modified = true;
                    }
                }

                if (modified)
                {
                    updateValueRanges.Add(new ValueRange
                    {
                        Values = values,
                        Range = valueRange.Range
                    });
                }
            }

            if (!updateValueRanges.Any()) continue;

            var batchUpdateValuesRequest = new BatchUpdateValuesRequest
            {
                Data = updateValueRanges,
                ValueInputOption = "USER_ENTERED"
            };
            await _sheetsService.Spreadsheets.Values.BatchUpdate(batchUpdateValuesRequest, spreadsheetId).ExecuteAsync();
        }
    }
    
    private (SheetsService sheetsService, DriveService driveService) InitializeGoogleApis(IConfigurableHttpClientInitializer credential)
    {
        var sheetsService = new SheetsService(new BaseClientService.Initializer
        {
            HttpClientInitializer = credential,
            ApplicationName = _config.Value.ApplicationName,
        });

        var driveService = new DriveService(new BaseClientService.Initializer
        {
            HttpClientInitializer = credential,
            ApplicationName = _config.Value.ApplicationName,
        });
        return (sheetsService, driveService);
    }

    private async Task<File?> FindFileAsync(string parentFolderId, string fileName)
    {
        if (_driveService is null)
            throw new ApplicationException("DriveService is not initialized.");

        var files = await FindFilesByFolderIdAsync(parentFolderId);

        return files.FirstOrDefault(x => x.Name == fileName);
    }

    private async Task<IList<File>> FindFilesByFolderIdAsync(string parentFolderId)
    {
        if (_driveService is null)
            throw new ApplicationException("DriveService is not initialized.");

        var listRequest = _driveService.Files.List();
        listRequest.IncludeTeamDriveItems = true;
        listRequest.SupportsTeamDrives = true;
        listRequest.Q = $"'{parentFolderId}' in parents and trashed = false";
        var files = await listRequest.ExecuteAsync();
        return files.Files;
    }

    private async Task<Sheet?> FindSheetAsync(string spreadsheetId, string sheetName)
    {
        if (_sheetsService is null)
            throw new ApplicationException("SheetsService is not initialized.");
        
        var spreadSheet = await _sheetsService.Spreadsheets.Get(spreadsheetId).ExecuteAsync();
        return spreadSheet?.Sheets.FirstOrDefault(x => x.Properties.Title == sheetName);
    }
    
    private async Task<IList<Sheet>?> FindSheetBySpreadsheetIdAsync(string spreadsheetId) 
    {
        if (_sheetsService is null)
            throw new ApplicationException("SheetsService is not initialized.");

        var spreadSheet = await _sheetsService.Spreadsheets.Get(spreadsheetId).ExecuteAsync();
        return spreadSheet?.Sheets;
    }

    private async Task<Sheet?> FindSheetAsync(string spreadsheetId, int sheetId)
    {
        if (_sheetsService is null)
            throw new ApplicationException("SheetsService is not initialized.");
        
        var spreadSheet = await _sheetsService.Spreadsheets.Get(spreadsheetId).ExecuteAsync();
        return spreadSheet?.Sheets.FirstOrDefault(x => x.Properties.SheetId == sheetId);
    }

    private async Task<IList<ValueRange>?> GetRangesAsync(string spreadsheetId, IReadOnlyList<string> ranges,
        SpreadsheetsResource.ValuesResource.BatchGetRequest.MajorDimensionEnum majorDimension = SpreadsheetsResource.ValuesResource.BatchGetRequest.MajorDimensionEnum.ROWS)
    {
        if (_sheetsService is null) 
            throw new ApplicationException("SheetsService is not initialized.");
        var request = new SpreadsheetsResource.ValuesResource.BatchGetRequest(_sheetsService, spreadsheetId)
        {
            Ranges = ranges.ToArray(),
            MajorDimension = majorDimension
        };

        var response = await request.ExecuteAsync();
        return response?.ValueRanges;
    }
    
    private Task<File> CopySpreadsheetFromTemplateAsync(string title)
    {
        if (_driveService is null)
            throw new ApplicationException("DriveService is not initialized.");

        // copy the file
        var copyRequest = _driveService.Files.Copy(new File(), _config.Value.TemplateSpreadsheetId);
        copyRequest.Fields = "id";
        var copiedFile = copyRequest.Execute();

        // rename the file
        copiedFile = _driveService.Files.Get(copiedFile.Id).Execute();

        var fileId = copiedFile.Id;
        copiedFile.Id = null;
        copiedFile.Name = title;
        var updateRequest = _driveService.Files.Update(copiedFile, fileId);
        return updateRequest.ExecuteAsync();
    }

    private async Task<int?> CopySheetFromTemplateAsync(string destinationSpreadsheetId)
    {
        if (_sheetsService is null)
            throw new ApplicationException("SheetsService is not initialized.");

        var copySheetToAnotherSpreadsheetRequest = new CopySheetToAnotherSpreadsheetRequest
        {
            DestinationSpreadsheetId = destinationSpreadsheetId
        };
        
        var copyToRequest =_sheetsService.Spreadsheets.Sheets.CopyTo(copySheetToAnotherSpreadsheetRequest, _config.Value.TemplateSpreadsheetId, 0);
        var response = await copyToRequest.ExecuteAsync();

        return response?.SheetId;
    }
    
    private IEntity? FindEntity(string tableName)
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        var entityTypes = assemblies
            .SelectMany(x => x.GetTypes())
            .Where(x => x is { IsClass: true, IsAbstract: false, IsInterface: false } && typeof(IEntity).IsAssignableFrom(x))
            .ToList();

        var entityType = entityTypes.FirstOrDefault(x => x.GetCustomAttributes(false)
            .Any(y => y.GetType() == typeof(TableAttribute) && ((TableAttribute)y).Name == tableName));

        if (entityType is null) return null;

        return (IEntity)Activator.CreateInstance(entityType)!;
    }

    public void Dispose()
    {
        if (_disposed) return;
        _sheetsService?.Dispose();
        _driveService?.Dispose();
        _disposed = true;
    }
}