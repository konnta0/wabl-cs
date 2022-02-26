namespace Infrastructure.Cache.Repository;

internal interface ICacheableRepositoryFilter<T> : IDisposable
{
    IVolatileCacheClient CacheClient { get; set; }
    ValueTask<T> HandleAsync(string cacheString);
}
