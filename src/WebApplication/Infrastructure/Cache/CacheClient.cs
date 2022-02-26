using System.Text.Json;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using ZLogger;

namespace Infrastructure.Cache;

abstract class CacheClient : ICacheClient
{
    protected readonly ILogger _logger;
    protected readonly IConnectionMultiplexer _connectionMultiplexer;

    protected CacheClient(ILogger logger, IConnectionMultiplexer connectionMultiplexer)
    {
        _logger = logger;
        _connectionMultiplexer = connectionMultiplexer;
        _connectionMultiplexer.ErrorMessage += (sender, args) => _logger.ZLogError(args.Message);
        _connectionMultiplexer.InternalError += (sender, args) => _logger.ZLogError(args.Exception.Message);
        _connectionMultiplexer.ConnectionFailed += (sender, args) => _logger.ZLogError(args.Exception.Message);
        _connectionMultiplexer.ConnectionRestored += (sender, args) => _logger.ZLogInformation(args.Exception.Message);
    }

    public void Dispose()
    {
        _connectionMultiplexer.Dispose();
    }

    public virtual async Task<bool> KeyExistsAsync(string key)
    {
        return await _connectionMultiplexer.GetDatabase().KeyExistsAsync(key);
    }

    public virtual async Task<bool> KeyExpireAsync(string key, TimeSpan? expiry)
    {
        return await _connectionMultiplexer.GetDatabase().KeyExpireAsync(key, expiry);
    }

    public virtual async Task<bool> KeyExpireAsync(string key, DateTime? expiry)
    {
        return await _connectionMultiplexer.GetDatabase().KeyExpireAsync(key, expiry);
    }

    public virtual async Task<bool> KeyPersistAsync(string key)
    {
        return await _connectionMultiplexer.GetDatabase().KeyPersistAsync(key);
    }

    public virtual async Task<bool> HashSetAsync<T>(string key, T value)
    {
        return await _connectionMultiplexer.GetDatabase().HashSetAsync(key, nameof(CacheClient), JsonSerializer.Serialize(value));
    }

    public virtual async Task<T?> HashGetAsync<T>(string key)
    {
        var cacheString = await HashGetAsync(key);
        if (cacheString is null) return default;
        return JsonSerializer.Deserialize<T>(cacheString);
    }

    public virtual async Task<string?> HashGetAsync(string key)
    {
        var cacheValue = await _connectionMultiplexer.GetDatabase().HashGetAsync(key, nameof(CacheClient));
        if (!cacheValue.HasValue) return null;
        return cacheValue;
    }

    public virtual async Task<bool> KeyDeleteAsync<T>(string key)
    {
        return await _connectionMultiplexer.GetDatabase().KeyDeleteAsync(key);
    }
}