using DatabaseMigration.Command.SeedCreate;
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
        
        (_sheetsService, _driveService) = InitializeGoogleApis(credential);

        var file = await FindFileAsync(_config.Value.SpreadsheetFolderId, tableGroupName);
        var alreadyCreatedSpreadSheet = file is not null;

        if (alreadyCreatedSpreadSheet)
        {
            var sheet = await FindSheetAsync(file!.Id, tableName);
            if (sheet is not null)
            {
                throw new ApplicationException($"Table {tableName} already exists in {tableGroupName}.");
            }

            var copiedSheet = await CopySheetFromTemplateAsync(file.Id);
            if (copiedSheet is null)
            {
                throw new ApplicationException("");
            }
        }
        else
        {
            var createdSpreadSheet = await CopySpreadsheetFromTemplateAsync(tableGroupName);
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

        var listRequest = _driveService.Files.List();
        listRequest.IncludeTeamDriveItems = true;
        listRequest.SupportsTeamDrives = true;
        listRequest.Q = $"'{parentFolderId}' in parents and trashed = false";
        var files = await listRequest.ExecuteAsync();

        return files.Files.FirstOrDefault(x => x.Name == fileName);
    }

    private async Task<Sheet?> FindSheetAsync(string spreadSheetId, string sheetName)
    {
        if (_sheetsService is null)
            throw new ApplicationException("SheetsService is not initialized.");
        
        var spreadSheet = await _sheetsService.Spreadsheets.Get(spreadSheetId).ExecuteAsync();
        return spreadSheet?.Sheets.FirstOrDefault(x => x.Properties.Title == sheetName);
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
}