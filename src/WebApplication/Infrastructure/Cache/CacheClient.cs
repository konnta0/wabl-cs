using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace Infrastructure.Cache;

internal class CacheClient : ICacheClient
{
    private readonly ILogger<CacheClient> _logger;
    private readonly ICacheClientFactory _cacheClientFactory;
    private Lazy<IConnectionMultiplexer> _connectionMultiplexer;

    public CacheClient(ILogger<CacheClient> logger, ICacheClientFactory cacheClientFactory)
    {
        _logger = logger;
        _cacheClientFactory = cacheClientFactory;
        _connectionMultiplexer = new Lazy<IConnectionMultiplexer>(() =>
        { 
            var connectionMultiplexer = _cacheClientFactory.Create();
            connectionMultiplexer.ErrorMessage += (sender, args) =>
            {
                
            };
            connectionMultiplexer.InternalError += (sender, args) =>
            {
                
            };
            connectionMultiplexer.ConnectionFailed += (sender, args) =>
            {
                
            };
            connectionMultiplexer.ConnectionRestored += (sender, args) =>
            {
                
            };
            return connectionMultiplexer;
        });
    }
}