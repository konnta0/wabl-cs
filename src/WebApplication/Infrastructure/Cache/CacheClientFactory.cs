using Infrastructure.Core.Logging;
using StackExchange.Redis;
using ZLogger;

namespace Infrastructure.Cache;

internal static class CacheClientFactory
{
    public static IConnectionMultiplexer CreateVolatileCacheConnectionMultiplexer(CacheConfig cacheConfig)
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
    
    private static IConnectionMultiplexer Create(Action<ConfigurationOptions> configurationOptions)
    {
        var options = new ConfigurationOptions();
        configurationOptions(options);
        GlobalLogManager.GetLogger(nameof(CacheClientFactory))?.ZLogInformationWithPayload(options, "CacheClient options");
        return ConnectionMultiplexer.Connect(options);
    }
}