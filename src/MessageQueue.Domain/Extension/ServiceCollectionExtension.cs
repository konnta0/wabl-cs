using Microsoft.Extensions.DependencyInjection;

namespace MessageQueue.Domain.Extension;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddDomain(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }
}