using Infrastructure.Resource.Shared.Observability.Grafana;
using Infrastructure.Resource.Shared.Observability.Loki;
using Infrastructure.Resource.Shared.Observability.Mimir;
using Infrastructure.Resource.Shared.Observability.MinIO;
using Infrastructure.Resource.Shared.Observability.Pyroscope;
using Infrastructure.Resource.Shared.Observability.Tempo;
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