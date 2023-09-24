using Application.Core.BackgroundService;
using Application.Core.RequestHandler;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extension;

public static class ServiceCollection
{
    public static IServiceCollection AddUseCase(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        serviceCollection.AddUseCaseHandler();
        serviceCollection.AddBackgroundService();
        return serviceCollection;
    }
    
    private static IServiceCollection AddUseCaseHandler(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IUseCaseHandler, UseCaseHandler>();
        return serviceCollection;
    }
    
    private static IServiceCollection AddBackgroundService(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddHostedService<MemoryDatabaseLoader>();
        return serviceCollection;
    }
}