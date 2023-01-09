using Infrastructure.ContainerRegistry.Resource;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.ContainerRegistry.Extension
{
    internal static class ServiceCollectionExtension
    {
        internal static IServiceCollection AddContainerRegistry(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<Harbor>();
            serviceCollection.AddScoped<MinIO>();
            serviceCollection.AddScoped<ContainerRegistryComponent>();
            return serviceCollection;
        }        
    }
}