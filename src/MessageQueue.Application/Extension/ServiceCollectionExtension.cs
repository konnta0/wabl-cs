using MessagePipe;
using MessageQueue.Application.RequestHandler;
using Microsoft.Extensions.DependencyInjection;

namespace MessageQueue.Application.Extension;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMessagePipe(options =>
        {
#if DEBUG
            options.EnableCaptureStackTrace = true;
#endif
            options.InstanceLifetime = InstanceLifetime.Scoped;
        });
        return serviceCollection.AddUseCaseHandler();
    }
    
    private static IServiceCollection AddUseCaseHandler(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IUseCaseHandler, UseCaseHandler>();
        return serviceCollection;
    }
}