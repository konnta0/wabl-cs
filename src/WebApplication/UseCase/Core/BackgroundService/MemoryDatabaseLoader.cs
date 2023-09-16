using Microsoft.Extensions.Logging;
using ZLogger;

namespace UseCase.Core.BackgroundService;

internal sealed class MemoryDatabaseLoader : Microsoft.Extensions.Hosting.BackgroundService
{
    private readonly ILogger<MemoryDatabaseLoader> _logger;

    public MemoryDatabaseLoader(ILogger<MemoryDatabaseLoader> logger)
    {
        _logger = logger;
    }


    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        stoppingToken.Register(() => _logger.ZLogInformation("MemoryDatabaseLoader is stopping"));
        
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }
}