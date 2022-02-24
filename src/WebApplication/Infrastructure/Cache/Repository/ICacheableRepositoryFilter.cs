namespace Infrastructure.Cache.Repository;

internal interface ICacheableRepositoryFilter<T> : IDisposable
{
    ICacheClient CacheClient { get; set; }
    ValueTask<T> HandleAsync(string cacheString);
}
