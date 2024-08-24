using Microsoft.Extensions.DependencyInjection;

namespace MessageQueue.Infrastructure.Extension;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }
}