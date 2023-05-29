using Google.Apis.Sheets.v4;
using Microsoft.Extensions.Logging;
using ZLogger;

namespace DatabaseMigration.Command.SeedDownload;

// ReSharper disable once ClassNeverInstantiated.Global
public class SeedDownloadCommand : ConsoleAppBase
{
    private readonly ILogger<SeedDownloadCommand> _logger;
    private readonly IGoogleApiHelper _googleApiHelper;
    private readonly ISeedService _seedService;

    public SeedDownloadCommand(
        ILogger<SeedDownloadCommand> logger,
        IGoogleApiHelper googleApiHelper, 
        ISeedService seedService)
    {
        _logger = logger;
        _googleApiHelper = googleApiHelper;
        _seedService = seedService;
    }
    
    [Command("seed-download")]
    public async ValueTask RunAsync(
        [Option("o", "output seed directory path")] string outputSeedPath = "/src/Seed",
        [Option("t", "target table names")] string[]? tableNames = null)
    {
        _logger.ZLogInformation("Start seed download");
        var credential = await _googleApiHelper.GetGoogleCredentialAsync(SheetsService.Scope.Spreadsheets,
            SheetsService.Scope.Drive);

        var tables = tableNames ?? Array.Empty<string>();
        await _seedService.DownloadAsync(credential, outputSeedPath, tables);
    }
}