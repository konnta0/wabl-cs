using Microsoft.Extensions.Logging;
using ZLogger;

namespace DatabaseMigration;

public class SeedReader : ISeedReader
{
    private readonly ILogger<SeedReader> _logger;

    public SeedReader(ILogger<SeedReader> logger)
    {
        _logger = logger;
    }

    public void Dispose()
    {
    }

    public string Read(string path)
    {
        _logger.ZLogInformation($"read path : {path}");

        return string.Empty;
    }
}