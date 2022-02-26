using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace Infrastructure.Cache;

internal class VolatileCacheClient : CacheClient, IVolatileCacheClient
{
    public VolatileCacheClient(ILogger<VolatileCacheClient> logger, IConnectionMultiplexer volatileCacheConnectionMultiplexer) : base(logger, volatileCacheConnectionMultiplexer)
    {
    }
}