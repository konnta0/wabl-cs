namespace Infrastructure.Cache.Repository;

internal interface ICacheableRepositoryFilter : IDisposable
{
    ICacheClient CacheClient { get; set; }
}
