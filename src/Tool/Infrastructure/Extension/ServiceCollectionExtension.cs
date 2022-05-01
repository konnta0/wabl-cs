using Infrastructure.CI_CD;
using Infrastructure.CI_CD.Component;
using Infrastructure.ContainerRegistry.Component;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extension
{
    internal static class ServiceCollectionExtension
    {
        internal static IServiceCollection AddCICD(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<Tekton>();
            serviceCollection.AddScoped<CICD>();
            return serviceCollection;
        }

        internal static IServiceCollection AddContainerRegistry(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<Harbor>();
            serviceCollection.AddScoped<MinIO>();
            serviceCollection.AddScoped<ContainerRegistry.ContainerRegistry>();
            return serviceCollection;
        }
    }
}