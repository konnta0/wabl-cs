using Infrastructure.Observability.Resource.Grafana;
using Infrastructure.Observability.Resource.Loki;
using Infrastructure.Observability.Resource.Mimir;
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
            serviceCollection.AddScoped<GrafanaResource>();
            serviceCollection.AddScoped<LokiResource>();
            serviceCollection.AddScoped<TempoResource>();
            serviceCollection.AddScoped<MimirResource>();
            serviceCollection.AddScoped<MinIOResource>();
            serviceCollection.AddScoped<PyroscopeResource>();
            serviceCollection.AddScoped<ObservabilityComponent>();
            return serviceCollection;
        }
    }
}