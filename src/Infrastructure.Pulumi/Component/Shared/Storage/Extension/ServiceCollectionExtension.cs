using Infrastructure.Pulumi.Component.Shared.Storage.Dragonfly;
using Infrastructure.Pulumi.Component.Shared.Storage.MinIo;
using Infrastructure.Pulumi.Component.Shared.Storage.Redis;
using Infrastructure.Pulumi.Component.Shared.Storage.TiDB;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Pulumi.Component.Shared.Storage.Extension
{
    internal static class ServiceCollectionExtension
    {
        internal static IServiceCollection AddStorageComponent(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<TiDBComponent>();
            serviceCollection.AddScoped<DragonflyComponent>();
            serviceCollection.AddScoped<RedisComponent>();
            serviceCollection.AddScoped<MinIoComponent>();
            serviceCollection.AddScoped<StorageComponent>();
            return serviceCollection;
        }
    }
}