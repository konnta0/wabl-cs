using Infrastructure.Component.Shared.Storage.MinIo;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Component.Shared.Storage.Extension
{
    internal static class ServiceCollectionExtension
    {
        internal static IServiceCollection AddStorageComponent(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<MinIoComponent>();
            serviceCollection.AddScoped<StorageComponent>();
            return serviceCollection;
        }
    }
}