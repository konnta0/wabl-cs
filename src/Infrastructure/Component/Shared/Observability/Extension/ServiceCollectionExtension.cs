using Infrastructure.Component.Shared.Observability.Grafana;
using Infrastructure.Component.Shared.Observability.Loki;
using Infrastructure.Component.Shared.Observability.Mimir;
using Infrastructure.Component.Shared.Observability.Pyroscope;
using Infrastructure.Component.Shared.Observability.Tempo;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Component.Shared.Observability.Extension
{
    internal static class ServiceCollectionExtension
    {
        internal static IServiceCollection AddObservability(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<GrafanaComponent>();
            serviceCollection.AddScoped<LokiComponent>();
            serviceCollection.AddScoped<TempoComponent>();
            serviceCollection.AddScoped<MimirComponent>();
            serviceCollection.AddScoped<PyroscopeComponent>();
            serviceCollection.AddScoped<ObservabilityComponent>();
            return serviceCollection;
        }
    }
}