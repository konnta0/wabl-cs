using WebApplication.Application.Core.RequestHandler;
using WebApplication.Application.UseCase.MemoryDatabase.DataTransferObject;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ZLogger;

namespace WebApplication.Presentation.BackgroundService;

internal sealed class MemoryDatabaseLoaderService(
    ILogger<MemoryDatabaseLoaderService> logger,
    IServiceProvider serviceProvider)
    : Microsoft.Extensions.Hosting.BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        stoppingToken.Register(() => logger.ZLogInformation("MemoryDatabaseLoaderService is stopping"));
        
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }

        using var scope = serviceProvider.CreateScope();
        var useCaseHandler =
            scope.ServiceProvider.GetRequiredService<IUseCaseHandler>();

        _ = await useCaseHandler.InvokeAsync<LoadMemoryDatabaseUseCaseInput, LoadMemoryDatabaseUseCaseOutput>(new LoadMemoryDatabaseUseCaseInput(), stoppingToken);
    }
}