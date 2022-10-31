using Infrastructure.Observability.Resource.Grafana;
using Infrastructure.Observability.Resource.Loki;
using Infrastructure.Observability.Resource.MinIO;
using Infrastructure.Observability.Resource.Pyroscope;
using Infrastructure.Observability.Resource.Tempo;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Observability.Extension
{
    internal static class ServiceCollectionExtension
    {
        internal static IServiceCollection AddObservability(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<PyroscopeResource>();
            serviceCollection.AddScoped<TempoResource>();
            serviceCollection.AddScoped<LokiResource>();
            serviceCollection.AddScoped<MinIOResource>();
            serviceCollection.AddScoped<GrafanaResource>();
            serviceCollection.AddScoped<ObservabilityComponent>();
            return serviceCollection;
        }
    }
}