using Infrastructure.WebApplication.Resource.Dragonfly;
using Infrastructure.WebApplication.Resource.TiDB;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.WebApplication.Extension
{
    internal static class ServiceCollectionExtension
    {
        internal static IServiceCollection AddWebApplication(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<DragonflyResource>();
            serviceCollection.AddScoped<TiDBResource>();
            serviceCollection.AddScoped<WebApplicationComponent>();
            return serviceCollection;
        }
    }
}