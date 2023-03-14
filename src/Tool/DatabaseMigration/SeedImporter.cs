using Domain.Entity;
using Microsoft.Extensions.Logging;
using ZLogger;

namespace DatabaseMigration;

public class SeedImporter : ISeedImporter
{
    private readonly ILogger<SeedImporter> _logger;
    private readonly ISeedReader _seedReader;

    public SeedImporter(ILogger<SeedImporter> logger, ISeedReader seedReader)
    {
        _logger = logger;
        _seedReader = seedReader;
    }

    public async Task Import(IEntity entity)
    {
        _logger.ZLogInformation($"Import seed {nameof(entity)}");
        var path = nameof(entity);
        var seedData = await _seedReader.Read(path);
        
    }
}