using CloudStructures;
using Microsoft.Extensions.Logging;

namespace WebApplication.Infrastructure.Cache;

internal class DurableRedisProvider(ILogger<DurableRedisProvider> logger, RedisConnection redisConnection)
    : RedisProvider(logger,
        redisConnection), IDurableRedisProvider;