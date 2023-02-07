using Infrastructure.WebApplication.Resource.Dotnet;
using Infrastructure.WebApplication.Resource.OpenTelemetryOperator;
using Infrastructure.WebApplication.Resource.Promtail;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.WebApplication.Extension
{
    internal static class ServiceCollectionExtension
    {
        internal static IServiceCollection AddWebApplication(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<DotnetApplicationResource>();
            serviceCollection.AddScoped<WebApplicationComponent>();
            serviceCollection.AddScoped<OpenTelemetryOperatorResource>();
            serviceCollection.AddScoped<PromtailResource>();
            return serviceCollection;
        }
    }
}