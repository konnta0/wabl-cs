using Application.Core.RequestHandler;
using Application.UseCase.MemoryDatabase.DataTransferObject;
using Microsoft.Extensions.Logging;
using ZLogger;

namespace Presentation.BackgroundService;

internal sealed class MemoryDatabaseLoaderService : Microsoft.Extensions.Hosting.BackgroundService
{
    private readonly ILogger<MemoryDatabaseLoaderService> _logger;
    private readonly IUseCaseHandler _useCaseHandler;

    public MemoryDatabaseLoaderService(
        ILogger<MemoryDatabaseLoaderService> logger, 
        IUseCaseHandler useCaseHandler)
    {
        _logger = logger;
        _useCaseHandler = useCaseHandler;
    }


    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        stoppingToken.Register(() => _logger.ZLogInformation("MemoryDatabaseLoaderService is stopping"));
        
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }

        _= await _useCaseHandler.InvokeAsync<LoadMemoryDatabaseUseCaseInput, LoadMemoryDatabaseUseCaseOutput>(new ());
    }
}