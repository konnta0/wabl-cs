namespace Domain.Repository;

// TODO消す->CacheableRepositoryOutputAttributeに統合
public interface ICacheableRepositoryInput : IRepositoryInput
{
    string CacheKey { get; }
    TimeSpan CacheExpiry { get; }
}