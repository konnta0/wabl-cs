using Microsoft.Extensions.DependencyInjection;

namespace WebApplication.Presentation.BackgroundService.Extension;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddBackgroundService(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddHostedService<MemoryDatabaseLoaderService>();
        return serviceCollection;
    }
}