using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Text;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ZLogger;

namespace DatabaseMigration.Command;

[Command("seed-import")]
public class SeedImportCommand : ConsoleAppBase
{
    private readonly ILogger<SeedImportCommand> _logger;
    private readonly IDbContextHolder _dbContextHolder;
    private readonly ISeedImporter _seedImporter;

    public SeedImportCommand(ILogger<SeedImportCommand> logger, ISeedImporter seedImporter, IDbContextHolder dbContextHolder)
    {
        _logger = logger;
        _seedImporter = seedImporter;
        _dbContextHolder = dbContextHolder;
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