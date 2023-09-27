using Application.Core.RequestHandler;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extension;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddUseCase(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        serviceCollection.AddUseCaseHandler();
        return serviceCollection;
    }
    
    private static IServiceCollection AddUseCaseHandler(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IUseCaseHandler, UseCaseHandler>();
        return serviceCollection;
    }
}