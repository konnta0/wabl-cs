using Infrastructure.CI_CD;
using Infrastructure.CI_CD.Tekton;
using Infrastructure.ContainerRegistry.Harbor;
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
            return serviceCollection;
        }
    }
}