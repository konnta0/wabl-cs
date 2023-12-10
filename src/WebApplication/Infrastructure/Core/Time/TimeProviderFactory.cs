using Infrastructure.Cache;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Infrastructure.Core.Time;

public static class TimeProviderFactory
{
    public static TimeProvider CreateTimeProvider<T>(IWebHostEnvironment hostEnvironment, TimeConfig config, IDurableRedisProvider redisProvider)
        where T : MutableTimeProvider
    {
        var timeProvider = Activator.CreateInstance(typeof(T), config);
        if (timeProvider is null) throw new InvalidOperationException();

        var mutableTimeProvider = timeProvider as MutableTimeProvider ?? throw new InvalidOperationException();

        if (hostEnvironment.IsProduction()) return mutableTimeProvider;

        var redisValue = redisProvider.Connection.GetConnection().GetDatabase().StringGet("TimeProvider:DiffTicks");
        if (redisValue.HasValue)
        {
            mutableTimeProvider.SetDiffTicks((long)redisValue);
        }

        return mutableTimeProvider;
    }
}