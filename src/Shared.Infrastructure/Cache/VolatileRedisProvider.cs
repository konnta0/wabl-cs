using CloudStructures;
using Microsoft.Extensions.Logging;

namespace WebApplication.Infrastructure.Cache;

internal class VolatileRedisProvider(ILogger<VolatileRedisProvider> logger, RedisConnection redisConnection)
    : RedisProvider(logger,
        redisConnection), IVolatileRedisProvider;