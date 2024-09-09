
using CloudStructures;


namespace WebApplication.Infrastructure.Cache;

public interface IRedisProvider
{
    RedisConnection Connection { get; }
}