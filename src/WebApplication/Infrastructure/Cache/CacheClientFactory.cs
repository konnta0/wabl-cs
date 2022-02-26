using StackExchange.Redis;

namespace Infrastructure.Cache;

internal static class CacheClientFactory
{
    public static IConnectionMultiplexer CreateVolatileCacheConnectionMultiplexer()
    {
        return Create("REDIS_HOST", "REDIS_PORT");
    }

    private static IConnectionMultiplexer Create(string hostEnvironmentName, string portEnvironmentName)
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

        return Create(options =>
        {
            options.EndPoints.Add(host, port);
        });
    }
    
    private static IConnectionMultiplexer Create(Action<ConfigurationOptions> configurationOptions)
    {
        var options = new ConfigurationOptions();

        configurationOptions(options);
        return ConnectionMultiplexer.Connect(options);
    }
}