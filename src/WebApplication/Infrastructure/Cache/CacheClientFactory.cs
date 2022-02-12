using StackExchange.Redis;

namespace Infrastructure.Cache;

internal class CacheClientFactory : ICacheClientFactory
{
    public IConnectionMultiplexer Create()
    {
        var host = Environment.GetEnvironmentVariable("REDIS_HOST");

        if (host is null or "")
        {
            throw new ApplicationException();
        }

        if (int.TryParse(Environment.GetEnvironmentVariable("REDIS_PORT"), out var port))
        {
            throw new ApplicationException();
        }

        return Create(options =>
        {
            options.EndPoints.Add(host, port);
        });
    }

    public IConnectionMultiplexer Create(Action<ConfigurationOptions> configurationOptions)
    {
        var options = new ConfigurationOptions();

        configurationOptions(options);
        return ConnectionMultiplexer.Connect(options);
    }
}