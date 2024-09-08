using MessagePipe;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplication.Application.Core.RequestHandler;

namespace WebApplication.Application.Extension;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddUseCase(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        serviceCollection.AddMessagePipe(options =>
        {
#if DEBUG
            options.EnableCaptureStackTrace = true;
#endif
            options.InstanceLifetime = InstanceLifetime.Scoped;
        });
        serviceCollection.AddUseCaseHandler();
        return serviceCollection;
    }
    
    private static IServiceCollection AddUseCaseHandler(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IUseCaseHandler, UseCaseHandler>();
        return serviceCollection;
    }
}