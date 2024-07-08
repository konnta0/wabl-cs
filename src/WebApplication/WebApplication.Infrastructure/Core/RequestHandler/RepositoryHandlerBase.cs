using MessagePipe;
using WebApplication.Domain.Repository;
using WebApplication.Infrastructure.Cache;
using WebApplication.Infrastructure.Core.Instrumentation.Repository;

namespace WebApplication.Infrastructure.Core.RequestHandler;

public abstract class RepositoryHandlerBase<TInput, TOutput>(
    IVolatileRedisProvider volatileRedisProvider,
    IRepositoryActivityStarter activityStarter)
    : IAsyncRequestHandler<IRepositoryInput, IRepositoryOutput?>
    where TInput : IRepositoryInput
    where TOutput : IRepositoryOutput
{
    protected IVolatileRedisProvider VolatileRedisProvider { get; } = volatileRedisProvider;
    protected IRepositoryActivityStarter ActivityStarter { get; } = activityStarter;

    public async ValueTask<IRepositoryOutput?> InvokeAsync(IRepositoryInput request, CancellationToken cancellationToken = new ())
    {
        if (request is not TInput input)
        {
            return default;
        }
        using var activity = ActivityStarter.Start();
        activity?.SetTag("inputType", typeof(TInput).Name);
        activity?.SetTag("outputType", typeof(TOutput).Name);

        var isCacheableInput = request.GetType().GetInterfaces().Contains(typeof(ICacheableRepositoryInput));
        var cacheKey = string.Empty;
        var expiry = TimeSpan.Zero;
        if (isCacheableInput)
        {
            var cacheableInput = (ICacheableRepositoryInput) input;
            cacheKey = cacheableInput.CacheKey;
            expiry = cacheableInput.CacheExpiry;

            var redisString = VolatileRedisProvider.String<object>(cacheableInput.CacheKey, cacheableInput.CacheExpiry);
            var redisResult = await redisString.GetAsync();

            if (redisResult.HasValue)
            {
                if (redisResult.Value is TOutput o)
                {
                    activity?.SetTag("cache", "hit");
                    activity?.SetTag("cacheKey", cacheKey);
                    return o;
                }

                activity?.SetTag("cache", "miss");
            }
        }
        
        var output = await InvokeInternalAsync(input, cancellationToken);

        if (isCacheableInput && output is not null)
        {
            var redisString = VolatileRedisProvider.String<object>(cacheKey, expiry);
            var cached = await redisString.SetAsync(output);
            activity?.SetTag("cache", "set");
            activity?.SetTag("cacheKey", cacheKey);
            activity?.SetTag("cacheExpiry", expiry.ToString());
            activity?.SetTag("cached", cached.ToString());
        }
        
        return output;
    }
    
    protected abstract ValueTask<IRepositoryOutput?> InvokeInternalAsync(TInput input, CancellationToken cancellationToken = new());
}