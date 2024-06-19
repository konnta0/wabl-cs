using ConsoleAppFramework;
using Google.Apis.Drive.v3;
using Google.Apis.Sheets.v4;
using Microsoft.Extensions.Logging;
using Tool.DatabaseMigration.Domain.Internal.GoogleApi;
using Tool.DatabaseMigration.Domain.Service.Seed;
using ZLogger;

namespace Tool.DatabaseMigration.Command.Seed;

// ReSharper disable once UnusedType.Global
internal sealed class SeedRenameLabelCommand(
    ILogger<SeedRenameLabelCommand> logger,
    IGoogleApiHelper googleApiHelper,
    ISeedService seedService)
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="labels">-l, rename target labels</param>
    /// <param name="newLabel">-n, rename new label</param>
    [Command("rename-seed-label")]
    // ReSharper disable once UnusedMember.Global
    public async Task RenameSeedLabelsAsync(string[] labels, string newLabel)
    {
        logger.ZLogInformation("Start rename seed labels");
        var credential = await googleApiHelper.GetGoogleCredentialAsync(SheetsService.Scope.Spreadsheets, DriveService.Scope.Drive);

        await seedService.RenameLabelsAsync(credential, labels, newLabel);
        logger.ZLogInformation("End rename seed labels");
    }
}