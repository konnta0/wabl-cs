using Infrastructure.Component.WebApplication.Dotnet;
using Infrastructure.Component.WebApplication.OpenTelemetryOperator;
using Infrastructure.Component.WebApplication.Promtail;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.WebApplication.Extension
{
    internal static class ServiceCollectionExtension
    {
        internal static IServiceCollection AddWebApplication(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<DotnetApplicationResource>();
            serviceCollection.AddScoped<WebApplicationComponent>();
            serviceCollection.AddScoped<OpenTelemetryOperatorComponent>();
            serviceCollection.AddScoped<PromtailComponent>();
            return serviceCollection;
        }
    }
}