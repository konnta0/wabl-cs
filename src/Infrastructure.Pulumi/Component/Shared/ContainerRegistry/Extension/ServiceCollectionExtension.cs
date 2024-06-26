using Infrastructure.Pulumi.Component.Shared.ContainerRegistry.Harbor;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Pulumi.Component.Shared.ContainerRegistry.Extension
{
    internal static class ServiceCollectionExtension
    {
        internal static IServiceCollection AddContainerRegistry(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<HarborComponent>();
            serviceCollection.AddScoped<ContainerRegistryComponent>();
            return serviceCollection;
        }
    }
}