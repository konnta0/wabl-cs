using Domain.Repository;
using Domain.Repository.Departments;
using Domain.Repository.Departments.FindAll;
using Infrastructure.Cache;
using Infrastructure.Cache.Repository;
using Infrastructure.Core.RequestHandler;
using MessagePipe;

namespace Infrastructure.Repository.Departments.FindAll;

internal partial class AsyncFindAllDepartmentsHandlerFilter : AsyncRequestHandlerFilter<IDepartmentsRepositoryInputData, IDepartmentsRepositoryOutputData>, IAsyncRepositoryHandlerFilter<IFindAllDepartmentsRepositoryInputData, IFindAllDepartmentsRepositoryOutputData>, ICacheableRepositoryFilter
{
    public override async ValueTask<IDepartmentsRepositoryOutputData> InvokeAsync(IDepartmentsRepositoryInputData request, CancellationToken cancellationToken, Func<IDepartmentsRepositoryInputData, CancellationToken, ValueTask<IDepartmentsRepositoryOutputData>> next)
    {
        if (request is not FindAllDepartmentsRepositoryInputData data)
        {
            return await next(request, cancellationToken);
        }

        var isCacheableOutputData = typeof(IDepartmentsRepositoryOutputData).GetInterfaces().Contains(typeof(ICacheableRepositoryOutputData));
        var cacheKey = string.Empty;
        var expiry = TimeSpan.Zero;

        if (isCacheableOutputData)
        {
            var cacheableRepositoryOutputDataAttribute = (CacheableRepositoryOutputDataAttribute) Attribute.GetCustomAttribute(typeof(IFindAllDepartmentsRepositoryOutputData), typeof(CacheableRepositoryOutputDataAttribute));
            cacheKey = cacheableRepositoryOutputDataAttribute.CacheKeyName;
            expiry = cacheableRepositoryOutputDataAttribute.Expiry;
            
            var cacheResponse = await CacheClient.HashGetAsync<IFindAllDepartmentsRepositoryOutputData>(cacheableRepositoryOutputDataAttribute.CacheKeyName);

            if (cacheResponse is not null)
            {
                return cacheResponse;
            }
        }

        var handleResponse = await HandleAsync(data);

        if (isCacheableOutputData)
        {
            var cached = await CacheClient.HashSetAsync(cacheKey, handleResponse);
            if (cached && expiry != TimeSpan.Zero)
            {
                await CacheClient.KeyExpireAsync(cacheKey, expiry);
            }
        }

        return handleResponse;
    }
}