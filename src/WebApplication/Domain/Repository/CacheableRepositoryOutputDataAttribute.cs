namespace Domain.Repository;

[AttributeUsage(AttributeTargets.Interface)]
public class CacheableRepositoryOutputDataAttribute : Attribute
{
    public string CacheKeyName;
    public TimeSpan Expiry;
    
    public CacheableRepositoryOutputDataAttribute(string cacheKeyName, long expiryTick)
    {
        CacheKeyName = cacheKeyName;
        Expiry = new TimeSpan(expiryTick);
    }
}