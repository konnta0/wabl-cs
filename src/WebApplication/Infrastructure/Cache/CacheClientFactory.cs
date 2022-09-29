using Infrastructure.Core;
using StackExchange.Redis;
using ZLogger;

namespace Infrastructure.Cache;

internal static class CacheClientFactory
{
    public static IConnectionMultiplexer CreateVolatileCacheConnectionMultiplexer()
    {
        return Create("REDIS_HOST", "REDIS_PORT", "REDIS_USER", "REDIS_PASSWORD");
    }

    private static IConnectionMultiplexer Create(string hostEnvironmentName, string portEnvironmentName, string userEnvironmentName, string passwordEnvironmentName)
    {
        var host = Environment.GetEnvironmentVariable(hostEnvironmentName);

        if (host is null or "")
        {
            throw new ApplicationException();
        }

        if (!int.TryParse(Environment.GetEnvironmentVariable(portEnvironmentName), out var port))
        {
            throw new ApplicationException();
        }

        var user = Environment.GetEnvironmentVariable(userEnvironmentName);
        if (user is null or "")
        {
            throw new ApplicationException();
        }

        var password = Environment.GetEnvironmentVariable(passwordEnvironmentName);
        if (user is null or "")
        {
            throw new ApplicationException();
        }

        return Create(options =>
        {
            options.User = user;
            options.Password = password;
            options.EndPoints.Add(host, port);
        });
    }
    
    private static IConnectionMultiplexer Create(Action<ConfigurationOptions> configurationOptions)
    {
        var options = new ConfigurationOptions();
        configurationOptions(options);
        GlobalLogManager.GetLogger(nameof(CacheClientFactory)).ZLogInformation("CacheClient options", options);
        return ConnectionMultiplexer.Connect(options);
    }
}