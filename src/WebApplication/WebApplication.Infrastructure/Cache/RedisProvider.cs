using CloudStructures;
using Microsoft.Extensions.Logging;
using ZLogger;

namespace WebApplication.Infrastructure.Cache;

internal abstract class RedisProvider : IRedisProvider
{
    protected readonly ILogger Logger;

    public RedisConnection Connection { get; }

    protected RedisProvider(ILogger logger, RedisConnection redisConnection)
    {
        Logger = logger;
        Connection = redisConnection;
        var connectionMultiplexer = Connection.GetConnection();
        connectionMultiplexer.ErrorMessage += (sender, args) => Logger.ZLogErrorWithPayload(args, "ConnectionMultiplexer ErrorMessage");
        connectionMultiplexer.InternalError += (sender, args) => Logger.ZLogErrorWithPayload(args, "ConnectionMultiplexer InternalError");
        connectionMultiplexer.ConnectionFailed += (sender, args) => Logger.ZLogErrorWithPayload(args, "ConnectionMultiplexer ConnectionFailed");
        connectionMultiplexer.ConnectionRestored += (sender, args) => Logger.ZLogInformationWithPayload(args, "ConnectionMultiplexer ConnectionRestored");
    }

    public void Dispose()
    {
    }
}