using DatabaseMigration.Domain.Internal.GoogleApi;
using DatabaseMigration.Domain.Service.Seed;
using Google.Apis.Sheets.v4;
using Microsoft.Extensions.Logging;
using ZLogger;

namespace DatabaseMigration.Command.Seed;

// ReSharper disable once ClassNeverInstantiated.Global
internal sealed class SeedCreateCommand : ConsoleAppBase
{
    private readonly ILogger<SeedCreateCommand> _logger;
    private readonly IGoogleApiHelper _googleApiHelper;
    private readonly ISeedService _seedService;

    public SeedCreateCommand(
        ILogger<SeedCreateCommand> logger, 
        IGoogleApiHelper googleApiHelper,
        ISeedService seedService)
    {
        _logger = logger;
        _googleApiHelper = googleApiHelper;
        _seedService = seedService;
    }
    
    [Command("seed-create")]
    public async ValueTask<int> RunAsync(
        [Option("g", "table group name")] string groupName,
        [Option("t", "table name")] string tableName)
    {
        _logger.ZLogInformation("Start seed create");

        var credential = await _googleApiHelper.GetGoogleCredentialAsync(SheetsService.Scope.Spreadsheets,
            SheetsService.Scope.Drive);

        await _seedService.CreateAsync(credential, groupName, tableName);
        return 0;
    }
}