
using CloudStructures;


namespace Infrastructure.Cache;

public interface IRedisProvider
{
    RedisConnection Connection { get; }
}