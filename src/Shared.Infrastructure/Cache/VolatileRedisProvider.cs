using CloudStructures;
using Microsoft.Extensions.Logging;

namespace Shared.Infrastructure.Cache;

internal class VolatileRedisProvider(ILogger<VolatileRedisProvider> logger, RedisConnection redisConnection)
    : RedisProvider(logger,
        redisConnection), IVolatileRedisProvider;