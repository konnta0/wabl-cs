using Infrastructure.Component.WebApplication.OpenTelemetryOperator;
using Infrastructure.Component.WebApplication.Promtail;
using Infrastructure.Component.WebApplication.WebApi;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Component.WebApplication.Extension
{
    internal static class ServiceCollectionExtension
    {
        internal static IServiceCollection AddWebApplication(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<WebApiComponent>();
            serviceCollection.AddScoped<WebApplicationComponent>();
            serviceCollection.AddScoped<OpenTelemetryOperatorComponent>();
            serviceCollection.AddScoped<PromtailComponent>();
            return serviceCollection;
        }
    }
}