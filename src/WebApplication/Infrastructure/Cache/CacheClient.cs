using System.Text.Json;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using ZLogger;

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
                _logger.ZLogError(args.Message);
            };
            connectionMultiplexer.InternalError += (sender, args) =>
            {
                _logger.ZLogError(args.Exception.Message);
            };
            connectionMultiplexer.ConnectionFailed += (sender, args) =>
            {
                _logger.ZLogError(args.Exception.Message);
            };
            connectionMultiplexer.ConnectionRestored += (sender, args) =>
            {
                _logger.ZLogInformation(args.Exception.Message);
            };
            return connectionMultiplexer;
        });
    }

    public void Dispose()
    {
        _connectionMultiplexer.Value.Dispose();
    }

    public async Task<bool> KeyExistsAsync(string key)
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

    public async Task<T?> HashGetAsync<T>(string key)
    {
        var cacheValue = await _connectionMultiplexer.Value.GetDatabase().HashGetAsync(key, nameof(CacheClient));

        if (!cacheValue.HasValue) return default;

        return JsonSerializer.Deserialize<T>(cacheValue); 
    }

    public async Task<bool> KeyDeleteAsync<T>(string key)
    {
        return await _connectionMultiplexer.Value.GetDatabase().KeyDeleteAsync(key);
    }
}