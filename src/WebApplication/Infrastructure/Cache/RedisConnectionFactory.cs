using CloudStructures;
using Infrastructure.Core.Logging;
using StackExchange.Redis;
using ZLogger;

namespace Infrastructure.Cache;

internal static class RedisConnectionFactory
{
    public static RedisConnection CreateVolatileConnection(CacheConfig cacheConfig)
    {
        return Create(options =>
        {
            options.AbortOnConnectFail = false;
            options.Ssl = false;
            options.User = cacheConfig.User;
            options.Password = cacheConfig.Password;
            options.EndPoints.Add(cacheConfig.Host, int.Parse(cacheConfig.Port));
        });
    }
    
    private static RedisConnection Create(Action<ConfigurationOptions> configurationOptions)
    {
        var options = new ConfigurationOptions();
        configurationOptions(options);
        GlobalLogManager.GetLogger(nameof(RedisConnectionFactory))?.ZLogInformationWithPayload(options, "CacheClient options");
        
        var config = new RedisConfig("volatile", options);
        return new RedisConnection(config);
    }
}