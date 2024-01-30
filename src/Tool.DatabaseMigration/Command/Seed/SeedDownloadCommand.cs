using Google.Apis.Sheets.v4;
using Microsoft.Extensions.Logging;
using Tool.DatabaseMigration.Domain.Internal.GoogleApi;
using Tool.DatabaseMigration.Domain.Service.Seed;
using ZLogger;

namespace Tool.DatabaseMigration.Command.Seed;

// ReSharper disable once ClassNeverInstantiated.Global
internal sealed class SeedDownloadCommand : ConsoleAppBase
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