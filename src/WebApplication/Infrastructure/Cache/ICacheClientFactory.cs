using StackExchange.Redis;

namespace Infrastructure.Cache;

internal interface ICacheClientFactory
{
    IConnectionMultiplexer Create();
    IConnectionMultiplexer Create(Action<ConfigurationOptions> configurationOptions);
}