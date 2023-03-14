using System.Text;
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

    public Task<string> Read(string path)
    {
        _logger.ZLogInformation($"read path : {path}");
        using var streamReader = new StreamReader(path, Encoding.UTF8);
        return streamReader.ReadToEndAsync();
    }
}