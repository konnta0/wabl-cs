using System.Text.Json;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using ZLogger;

namespace Infrastructure.Cache;

abstract class CacheClient : ICacheClient
{
    protected readonly ILogger Logger;
    protected readonly IConnectionMultiplexer ConnectionMultiplexer;

    protected CacheClient(ILogger logger, IConnectionMultiplexer connectionMultiplexer)
    {
        Logger = logger;
        ConnectionMultiplexer = connectionMultiplexer;
        ConnectionMultiplexer.ErrorMessage += (sender, args) => Logger.ZLogErrorWithPayload(args, "ConnectionMultiplexer ErrorMessage");
        ConnectionMultiplexer.InternalError += (sender, args) => Logger.ZLogErrorWithPayload(args, "ConnectionMultiplexer InternalError");
        ConnectionMultiplexer.ConnectionFailed += (sender, args) => Logger.ZLogErrorWithPayload(args, "ConnectionMultiplexer ConnectionFailed");
        ConnectionMultiplexer.ConnectionRestored += (sender, args) => Logger.ZLogInformationWithPayload(args, "ConnectionMultiplexer ConnectionRestored");
    }

    public void Dispose()
    {
    }

    public virtual Task<bool> KeyExistsAsync(string key)
    {
        return ConnectionMultiplexer.GetDatabase().KeyExistsAsync(key);
    }

    public virtual Task<bool> KeyExpireAsync(string key, TimeSpan? expiry)
    {
        return ConnectionMultiplexer.GetDatabase().KeyExpireAsync(key, expiry);
    }

    public virtual Task<bool> KeyExpireAsync(string key, DateTime? expiry)
    {
        return ConnectionMultiplexer.GetDatabase().KeyExpireAsync(key, expiry);
    }

    public virtual Task<bool> KeyPersistAsync(string key)
    {
        return ConnectionMultiplexer.GetDatabase().KeyPersistAsync(key);
    }

    public virtual Task<bool> SetAddAsync(string key, string value)
    {
        return ConnectionMultiplexer.GetDatabase().SetAddAsync(key, value);
    }

    public virtual Task<bool> HashSetAsync<T>(string key, T value)
    {
        return ConnectionMultiplexer.GetDatabase().HashSetAsync(key, nameof(CacheClient), JsonSerializer.Serialize(value));
    }

    public virtual async Task<T?> HashGetAsync<T>(string key)
    {
        var cacheString = await HashGetAsync(key);
        if (cacheString is null) return default;
        return JsonSerializer.Deserialize<T>(cacheString);
    }

    public virtual async Task<string?> HashGetAsync(string key)
    {
        var cacheValue = await ConnectionMultiplexer.GetDatabase().HashGetAsync(key, nameof(CacheClient));
        if (!cacheValue.HasValue) return null;
        return cacheValue;
    }

    public virtual Task<bool> KeyDeleteAsync<T>(string key)
    {
        return ConnectionMultiplexer.GetDatabase().KeyDeleteAsync(key);
    }
}