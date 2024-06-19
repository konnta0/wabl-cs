using ConsoleAppFramework;
using Google.Apis.Sheets.v4;
using Microsoft.Extensions.Logging;
using Tool.DatabaseMigration.Domain.Internal.GoogleApi;
using Tool.DatabaseMigration.Domain.Service.Seed;
using ZLogger;

namespace Tool.DatabaseMigration.Command.Seed;

// ReSharper disable once ClassNeverInstantiated.Global
internal sealed class SeedDownloadCommand(
    ILogger<SeedDownloadCommand> logger,
    IGoogleApiHelper googleApiHelper,
    ISeedService seedService)
{
    /// <summary>
    /// seed download
    /// </summary>
    /// <param name="outputSeedPath">-o, output seed directory path</param>
    /// <param name="tableNames">-t, target table names</param>
    [Command("seed-download")]
    public async Task RunAsync(string outputSeedPath = "/src/Seed", string[]? tableNames = null)
    {
        logger.ZLogInformation("Start seed download");
        var credential = await googleApiHelper.GetGoogleCredentialAsync(SheetsService.Scope.Spreadsheets,
            SheetsService.Scope.Drive);

        var tables = tableNames ?? Array.Empty<string>();
        await seedService.DownloadAsync(credential, outputSeedPath, tables);
    }
}