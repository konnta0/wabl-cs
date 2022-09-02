using Infrastructure.Certificate;
using Infrastructure.Observability;
using Infrastructure.Observability.Resource.Grafana;
using Infrastructure.Observability.Resource.Loki;
using Infrastructure.Observability.Resource.Tempo;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extension
{
    internal static class ServiceCollectionExtension
    {
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