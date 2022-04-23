using Domain.Entity;
using Microsoft.Extensions.Logging;
using ZLogger;

namespace DatabaseMigration;

public class SeedTruncate : ISeedTruncate
{
    private readonly ILogger<SeedTruncate> _logger;

    public SeedTruncate(ILogger<SeedTruncate> logger)
    {
        _logger = logger;
    }

    public async Task Truncate(IEntity entity)
    {
        _logger.ZLogInformation($"Truncate table {nameof(entity)}");
    }
}