using Infrastructure.Component.Shared.Observability.Grafana;
using Infrastructure.Component.Shared.Observability.Loki;
using Infrastructure.Component.Shared.Observability.Mimir;
using Infrastructure.Component.Shared.Observability.MinIO;
using Infrastructure.Component.Shared.Observability.Pyroscope;
using Infrastructure.Component.Shared.Observability.Tempo;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Resource.Shared.Observability.Extension
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