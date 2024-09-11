using CloudStructures;
using Microsoft.Extensions.DependencyInjection;
using Shared.Infrastructure.Cache;
using Shared.Infrastructure.Logging;

namespace Shared.Infrastructure.Extension;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddCacheClient(this IServiceCollection serviceCollection, CacheConfig cacheConfig, out RedisConnection volatileRedisConnection, out RedisConnection durableRedisConnection)
    {
        volatileRedisConnection = RedisConnectionFactory.CreateVolatileConnection(cacheConfig);
        var volatileConnection = volatileRedisConnection;
        serviceCollection.AddTransient<IVolatileRedisProvider>(delegate
        {
            return new VolatileRedisProvider(GlobalLogManager.GetLogger<VolatileRedisProvider>()!, volatileConnection);
        });

        durableRedisConnection = RedisConnectionFactory.CreateVolatileConnection(cacheConfig);
        var durableConnection = durableRedisConnection;
        serviceCollection.AddTransient<IDurableRedisProvider>(delegate
        {
            return new DurableRedisProvider(GlobalLogManager.GetLogger<DurableRedisProvider>()!, durableConnection);
        });
        return serviceCollection;
    }
}