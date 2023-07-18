
namespace Infrastructure.Cache;

public interface ICacheClient : IDisposable
{
    Task<bool> KeyExistsAsync(string key);
    Task<bool> KeyExpireAsync(string key, TimeSpan? expiry);
    Task<bool> KeyExpireAsync(string key, DateTime? expiry);
    Task<bool> KeyPersistAsync(string key);
    Task<bool> SetAddAsync(string key, string value);
    Task<bool> HashSetAsync<T>(string key, T value);
    Task<T?> HashGetAsync<T>(string key);
    Task<string?> HashGetAsync(string key);
    Task<object?> HashGetAsync(string key, Type returnType);
    Task<bool> KeyDeleteAsync<T>(string key);
}