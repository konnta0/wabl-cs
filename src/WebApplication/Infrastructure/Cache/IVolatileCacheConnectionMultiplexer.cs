using StackExchange.Redis;

namespace Infrastructure.Cache;

internal interface IVolatileCacheConnectionMultiplexer : IConnectionMultiplexer
{
}