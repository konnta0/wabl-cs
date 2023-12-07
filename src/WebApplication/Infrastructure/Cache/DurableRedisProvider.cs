using CloudStructures;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Cache;

internal class DurableRedisProvider(ILogger<DurableRedisProvider> logger, RedisConnection redisConnection)
    : RedisProvider(logger,
        redisConnection), IDurableRedisProvider;