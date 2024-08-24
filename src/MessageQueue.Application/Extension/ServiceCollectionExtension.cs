using Microsoft.Extensions.DependencyInjection;

namespace MessageQueue.Application.Extension;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }
}