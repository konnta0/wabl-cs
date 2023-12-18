using Infrastructure.Pulumi.Component.WebApplication.OpenTelemetryOperator;
using Infrastructure.Pulumi.Component.WebApplication.WebApi;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Pulumi.Component.WebApplication.Extension
{
    internal static class ServiceCollectionExtension
    {
        internal static IServiceCollection AddWebApplication(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<WebApiComponent>();
            serviceCollection.AddScoped<WebApplicationComponent>();
            serviceCollection.AddScoped<OpenTelemetryOperatorComponent>();
            return serviceCollection;
        }
    }
}