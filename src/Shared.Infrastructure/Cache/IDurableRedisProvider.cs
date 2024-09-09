using CloudStructures.Structures;

namespace WebApplication.Infrastructure.Cache;

public interface IDurableRedisProvider : IRedisProvider
{
    RedisBit Bit(string key) => new (Connection, key, null);

    RedisDictionary<TKey, TValue> Dictionary<TKey, TValue>(string key) where TKey : notnull => new (Connection, key, null);

    RedisGeo<T> Geo<T>(string key) => new (Connection, key, null);
    
    RedisHashSet<T> HashSet<T>(string key) where T : notnull => new (Connection, key, null);

    RedisHyperLogLog<T> HyperLogLog<T>(string key) where T : notnull => new (Connection, key, null);

    RedisList<T> List<T>(string key) where T : notnull => new (Connection, key, null);
    
    RedisLua RedisLua(string key) => new (Connection, key);

    RedisSet<T> Set<T>(string key) where T : notnull => new (Connection, key, null);
    
    RedisSortedSet<T> SortedSet<T>(string key) where T : notnull => new (Connection, key, null);

    RedisString<T> String<T>(string key) => new (Connection, key, null);
}