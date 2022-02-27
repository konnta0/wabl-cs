namespace Infrastructure.Cache.Repository;

internal interface ICacheableRepositoryFilter<T>
{
    IVolatileCacheClient CacheClient { get; set; }
    ValueTask<T> HandleAsync(string cacheString);
}
