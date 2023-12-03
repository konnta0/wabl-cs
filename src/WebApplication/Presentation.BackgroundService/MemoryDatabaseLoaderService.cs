using WebApplication.Application.Core.RequestHandler;
using WebApplication.Application.UseCase.MemoryDatabase.DataTransferObject;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ZLogger;

namespace Presentation.BackgroundService;

internal sealed class MemoryDatabaseLoaderService : Microsoft.Extensions.Hosting.BackgroundService
{
    private readonly ILogger<MemoryDatabaseLoaderService> _logger;
    private readonly IServiceProvider _serviceProvider;

    public MemoryDatabaseLoaderService(
        ILogger<MemoryDatabaseLoaderService> logger, 
        IServiceProvider serviceProvider)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
    }


    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        stoppingToken.Register(() => _logger.ZLogInformation("MemoryDatabaseLoaderService is stopping"));
        
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }

        using (var scope = _serviceProvider.CreateScope())
        {
            var useCaseHandler =
                scope.ServiceProvider.GetRequiredService<IUseCaseHandler>();

            _ = await useCaseHandler.InvokeAsync<LoadMemoryDatabaseUseCaseInput, LoadMemoryDatabaseUseCaseOutput>(new LoadMemoryDatabaseUseCaseInput(), stoppingToken);
        }
    }
}