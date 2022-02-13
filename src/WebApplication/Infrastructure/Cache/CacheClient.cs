using System.Text.Json;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace Infrastructure.Cache;

internal class CacheClient : ICacheClient
{
    private readonly ILogger<CacheClient> _logger;
    private readonly Lazy<IConnectionMultiplexer> _connectionMultiplexer;

    public CacheClient(ILogger<CacheClient> logger, ICacheClientFactory cacheClientFactory)
    {
        _logger = logger;
        _connectionMultiplexer = new Lazy<IConnectionMultiplexer>(() =>
        { 
            var connectionMultiplexer = cacheClientFactory.Create();
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

    public async Task<bool> KeyExists(string key)
    {
        return await _connectionMultiplexer.Value.GetDatabase().KeyExistsAsync(key);
    }

    public async Task<bool> KeyExpireAsync(string key, TimeSpan? expiry)
    {
        return await _connectionMultiplexer.Value.GetDatabase().KeyExpireAsync(key, expiry);
    }

    public async Task<bool> KeyExpireAsync(string key, DateTime? expiry)
    {
        return await _connectionMultiplexer.Value.GetDatabase().KeyExpireAsync(key, expiry);
    }

    public async Task<bool> KeyPersistAsync(string key)
    {
        return await _connectionMultiplexer.Value.GetDatabase().KeyPersistAsync(key);
    }

    public async Task<bool> HashSetAsync<T>(string key, T value)
    {
        return await _connectionMultiplexer.Value.GetDatabase().HashSetAsync(key, nameof(CacheClient), JsonSerializer.Serialize(value));
    }

    public async Task<bool> KeyDeleteAsync<T>(string key)
    {
        return await _connectionMultiplexer.Value.GetDatabase().KeyDeleteAsync(key);
    }
}