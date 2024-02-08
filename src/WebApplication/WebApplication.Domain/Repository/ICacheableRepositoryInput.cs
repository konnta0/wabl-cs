namespace WebApplication.Domain.Repository;

public interface ICacheableRepositoryInput : IRepositoryInput
{
    Type CacheOutputType { get; }
    string CacheKey { get; }
    TimeSpan CacheExpiry { get; }
}