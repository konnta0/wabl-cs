using CloudStructures;
using Microsoft.Extensions.Logging;

namespace Shared.Infrastructure.Cache;

internal class DurableRedisProvider(ILogger<DurableRedisProvider> logger, RedisConnection redisConnection)
    : RedisProvider(logger,
        redisConnection), IDurableRedisProvider;