using System.Text.Json;
using Domain.Repository;
using Infrastructure.Cache;
using Infrastructure.Core.Instrumentation.Repository;
using MessagePipe;

namespace Infrastructure.Core.RequestHandler;

internal abstract class RepositoryHandlerBase<TInput, TOutput> : IAsyncRequestHandler<IRepositoryInput, IRepositoryOutput?> where TInput : IRepositoryInput where TOutput : IRepositoryOutput
{
    protected IVolatileCacheClient CacheClient { get; init; }
    protected IRepositoryActivityStarter ActivityStarter { get; init; }
    
    protected RepositoryHandlerBase(
        IVolatileCacheClient cacheClient, 
        IRepositoryActivityStarter activityStarter)
    {
        CacheClient = cacheClient;
        ActivityStarter = activityStarter;
    }
    
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
            
            var cache = await CacheClient.HashGetAsync(cacheableInput.CacheKey, cacheableInput.CacheOutputType);

            if (cache is not null)
            {
                if (cache is TOutput o)
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
            var cached = await CacheClient.HashSetAsync(cacheKey, (object)output);
            if (cached && expiry != TimeSpan.Zero)
            {
                await CacheClient.KeyExpireAsync(cacheKey, expiry);
            }
            activity?.SetTag("cache", "set");
            activity?.SetTag("cacheKey", cacheKey);
            activity?.SetTag("cacheExpiry", expiry.ToString());
        }
        
        return output;
    }
    
    protected abstract ValueTask<IRepositoryOutput?> InvokeInternalAsync(TInput input, CancellationToken cancellationToken = new());
}