using System.ComponentModel.DataAnnotations.Schema;
using DatabaseMigration.Command.SeedCreate;
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

public class SeedService : ISeedService
{
    private readonly IOptions<SeedCreateConfig> _config;
    private SheetsService? _sheetsService;
    private DriveService? _driveService;

    public SeedService(IOptions<SeedCreateConfig> config)
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
}