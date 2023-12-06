using CloudStructures;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Cache;

internal class VolatileRedisProvider(ILogger<VolatileRedisProvider> logger, RedisConnection redisConnection)
    : RedisProvider(logger,
        redisConnection), IVolatileRedisProvider;