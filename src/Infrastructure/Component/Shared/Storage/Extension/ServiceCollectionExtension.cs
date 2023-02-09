using Infrastructure.Component.Shared.Storage.Dragonfly;
using Infrastructure.Component.Shared.Storage.MinIo;
using Infrastructure.Component.Shared.Storage.TiDB;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Component.Shared.Storage.Extension
{
    internal static class ServiceCollectionExtension
    {
        internal static IServiceCollection AddStorageComponent(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<TiDBComponent>();
            serviceCollection.AddScoped<DragonflyComponent>();
            serviceCollection.AddScoped<MinIoComponent>();
            serviceCollection.AddScoped<StorageComponent>();
            return serviceCollection;
        }
    }
}