
namespace Infrastructure.Cache;

public interface ICacheClient
{
    Task<bool> KeyExists(string key);
    Task<bool> KeyExpireAsync(string key, TimeSpan? expiry);
    Task<bool> KeyExpireAsync(string key, DateTime? expiry);
    Task<bool> KeyPersistAsync(string key);
    Task<bool> HashSetAsync<T>(string key, T value);
    Task<bool> KeyDeleteAsync<T>(string key);
}