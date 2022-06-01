using Infrastructure.Certificate;
using Infrastructure.CI_CD;
using Infrastructure.CI_CD.Component;
using Infrastructure.ContainerRegistry;
using Infrastructure.ContainerRegistry.Component;
using Infrastructure.Observability;
using Infrastructure.Observability.Component;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extension
{
    internal static class ServiceCollectionExtension
    {
        internal static IServiceCollection AddCICD(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<Tekton>();
            serviceCollection.AddScoped<CICDComponent>();
            return serviceCollection;
        }

        internal static IServiceCollection AddContainerRegistry(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<Harbor>();
            serviceCollection.AddScoped<MinIO>();
            serviceCollection.AddScoped<ContainerRegistryComponent>();
            return serviceCollection;
        }

        internal static IServiceCollection AddObservability(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<Tempo>();
            serviceCollection.AddScoped<Loki>();
            serviceCollection.AddScoped<Grafana>();
            serviceCollection.AddScoped<ObservabilityComponent>();
            return serviceCollection;
        }

        internal static IServiceCollection AddCertificate(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<CertManager>();
            serviceCollection.AddScoped<CertificateComponent>();
            return serviceCollection;
        }
    }
}