using ConsoleAppFramework;
using Google.Apis.Sheets.v4;
using Microsoft.Extensions.Logging;
using Tool.DatabaseMigration.Domain.Internal.GoogleApi;
using Tool.DatabaseMigration.Domain.Service.Seed;
using ZLogger;

namespace Tool.DatabaseMigration.Command.Seed;

// ReSharper disable once ClassNeverInstantiated.Global
internal sealed class SeedCreateCommand(
    ILogger<SeedCreateCommand> logger,
    IGoogleApiHelper googleApiHelper,
    ISeedService seedService)
{
    /// <summary>
    /// seed create
    /// </summary>
    /// <param name="groupName">-g, table group name</param>
    /// <param name="tableName">-t, table name</param>
    /// <returns></returns>
    [Command("seed-create")]
    public async Task<int> RunAsync(string groupName, string tableName)
    {
        logger.ZLogInformation("Start seed create");

        var credential = await googleApiHelper.GetGoogleCredentialAsync(SheetsService.Scope.Spreadsheets,
            SheetsService.Scope.Drive);

        await seedService.CreateAsync(credential, groupName, tableName);
        return 0;
    }
}