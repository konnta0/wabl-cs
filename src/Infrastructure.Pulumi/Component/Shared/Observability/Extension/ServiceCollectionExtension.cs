using Infrastructure.Pulumi.Component.Shared.Observability.Grafana;
using Infrastructure.Pulumi.Component.Shared.Observability.Loki;
using Infrastructure.Pulumi.Component.Shared.Observability.Mimir;
using Infrastructure.Pulumi.Component.Shared.Observability.Promtail;
using Infrastructure.Pulumi.Component.Shared.Observability.Pyroscope;
using Infrastructure.Pulumi.Component.Shared.Observability.Tempo;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Pulumi.Component.Shared.Observability.Extension
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
            serviceCollection.AddScoped<PromtailComponent>();

            return serviceCollection;
        }
    }
}