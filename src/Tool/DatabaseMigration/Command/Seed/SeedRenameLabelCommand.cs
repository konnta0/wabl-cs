using Google.Apis.Drive.v3;
using Google.Apis.Sheets.v4;
using Microsoft.Extensions.Logging;
using ZLogger;

namespace DatabaseMigration.Command.Seed;

// ReSharper disable once UnusedType.Global
public class SeedRenameLabelCommand : ConsoleAppBase
{
    private readonly ILogger<SeedRenameLabelCommand> _logger;
    private readonly IGoogleApiHelper _googleApiHelper;
    private readonly ISeedService _seedService;

    public SeedRenameLabelCommand(
        ILogger<SeedRenameLabelCommand> logger,
        IGoogleApiHelper googleApiHelper,
        ISeedService seedService)
    {
        _logger = logger;
        _googleApiHelper = googleApiHelper;
        _seedService = seedService;
    }
    
    [Command("rename-seed-label")]
    // ReSharper disable once UnusedMember.Global
    public async ValueTask RenameSeedLabelsAsync(
        [Option("l", "rename target labels")] string[] labels,
        [Option("n", "rename new label")] string newLabel)
    {
        _logger.ZLogInformation("Start rename seed labels");
        var credential = await _googleApiHelper.GetGoogleCredentialAsync(SheetsService.Scope.Spreadsheets, DriveService.Scope.Drive);

        await _seedService.RenameLabelsAsync(credential, labels, newLabel);
        _logger.ZLogInformation("End rename seed labels");
    }
}