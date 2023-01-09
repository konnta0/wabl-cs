using Infrastructure.Component.Shared.ContainerRegistry.Harbor;
using Infrastructure.Component.Shared.ContainerRegistry.Resource;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Component.Shared.ContainerRegistry.Extension
{
    internal static class ServiceCollectionExtension
    {
        internal static IServiceCollection AddContainerRegistry(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<HarborComponent>();
            serviceCollection.AddScoped<MinIO>();
            serviceCollection.AddScoped<ContainerRegistryComponent>();
            return serviceCollection;
        }        
    }
}