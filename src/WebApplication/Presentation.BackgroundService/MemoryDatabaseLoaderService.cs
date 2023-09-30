using Microsoft.Extensions.Logging;
using ZLogger;

namespace Presentation.BackgroundService;

internal sealed class MemoryDatabaseLoaderService : Microsoft.Extensions.Hosting.BackgroundService
{
    private readonly ILogger<MemoryDatabaseLoaderService> _logger;

    public MemoryDatabaseLoaderService(ILogger<MemoryDatabaseLoaderService> logger)
    {
        _logger = logger;
    }


    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        stoppingToken.Register(() => _logger.ZLogInformation("MemoryDatabaseLoaderService is stopping"));
        
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }
}