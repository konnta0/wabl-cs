using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UseCase.Core.BackgroundService;
using UseCase.Core.RequestHandler;

namespace UseCase.Extension;

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