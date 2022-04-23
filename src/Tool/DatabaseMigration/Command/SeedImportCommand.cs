using Domain.Entity;
using Microsoft.Extensions.Logging;
using ZLogger;

namespace DatabaseMigration.Command;

[Command("seed-import")]
public class SeedImportCommand : ConsoleAppBase
{
    private readonly ILogger<SeedImportCommand> _logger;
    private readonly ISeedImporter _seedImporter;
    private readonly ISeedTruncate _seedTruncate;

    public SeedImportCommand(ILogger<SeedImportCommand> logger, ISeedImporter seedImporter, ISeedTruncate seedTruncate)
    {
        _logger = logger;
        _seedImporter = seedImporter;
        _seedTruncate = seedTruncate;
    }

    [RootCommand]
    public async Task Run([Option("t", "target table")] string tableName = "",
        [Option("r", "reset table.")] bool resetTable = true)
    {
        Console.WriteLine(Context.Timestamp);
        
        // Get All Model from implement IEntity
        var models = LoadModels();
        try
        {
            // each
            if (string.IsNullOrEmpty(tableName))
            {
                
            }
            else
            {
                models.AsParallel().WithDegreeOfParallelism(4).Select(async model =>
                {
                    if (resetTable)
                    {
                        await _seedTruncate.Truncate(model);
                    }

                    _seedImporter.Import(model);
                });
            }
        }
        catch (Exception e)
        {
            _logger.ZLogErrorWithPayload(e, "Seed import failed");
        }
        finally
        {
            _seedImporter.Dispose();
        }
    }

    private IEnumerable<IEntity> LoadModels()
    {

        return Enumerable.Empty<IEntity>();
    }
}