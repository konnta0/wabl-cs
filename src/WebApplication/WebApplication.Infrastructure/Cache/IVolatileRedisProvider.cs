using CloudStructures.Structures;

namespace WebApplication.Infrastructure.Cache;

public interface IVolatileRedisProvider : IRedisProvider
{
    RedisBit Bit(string key, TimeSpan defaultExpiry) => new (Connection, key, defaultExpiry);

    RedisDictionary<TKey, TValue> Dictionary<TKey, TValue>(string key, TimeSpan defaultExpiry) where TKey : notnull => new (Connection, key, defaultExpiry);

    RedisGeo<T> Geo<T>(string key, TimeSpan defaultExpiry) => new (Connection, key, defaultExpiry);
    
    RedisHashSet<T> HashSet<T>(string key, TimeSpan defaultExpiry) where T : notnull => new (Connection, key, defaultExpiry);

    RedisHyperLogLog<T> HyperLogLog<T>(string key, TimeSpan defaultExpiry) where T : notnull => new (Connection, key, defaultExpiry);

    RedisList<T> List<T>(string key, TimeSpan defaultExpiry) where T : notnull => new (Connection, key, defaultExpiry);
    
    RedisLua RedisLua(string key) => new (Connection, key);

    RedisSet<T> Set<T>(string key, TimeSpan defaultExpiry) where T : notnull => new (Connection, key, defaultExpiry);
    
    RedisSortedSet<T> SortedSet<T>(string key, TimeSpan defaultExpiry) where T : notnull => new (Connection, key, defaultExpiry);

    RedisString<T> String<T>(string key, TimeSpan defaultExpiry) => new (Connection, key, defaultExpiry);
}