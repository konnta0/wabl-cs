using Infrastructure.Certificate;
using Infrastructure.ContainerRegistry;
using Infrastructure.ContainerRegistry.Resource;
using Infrastructure.Observability;
using Infrastructure.Observability.Resource.Grafana;
using Infrastructure.Observability.Resource.Loki;
using Infrastructure.Observability.Resource.Tempo;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extension
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

        internal static IServiceCollection AddObservability(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<TempoResource>();
            serviceCollection.AddScoped<LokiResource>();
            serviceCollection.AddScoped<GrafanaResource>();
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