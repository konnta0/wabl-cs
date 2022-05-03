using Domain.Repository;
using Domain.Repository.Department;
using Domain.Repository.Department.FindAll;
using Infrastructure.Cache.Repository;
using Infrastructure.Core.RequestHandler;
using MessagePipe;

namespace Infrastructure.Repository.Department.FindAll;

internal partial class AsyncFindAllDepartmentHandlerFilter : AsyncRequestHandlerFilter<IDepartmentRepositoryInputData, IDepartmentRepositoryOutputData>,
    IAsyncRepositoryHandlerFilter<IFindAllDepartmentRepositoryInputData, IFindAllDepartmentRepositoryOutputData>,
    ICacheableRepositoryFilter<IFindAllDepartmentRepositoryOutputData>
{
    public override async ValueTask<IDepartmentRepositoryOutputData> InvokeAsync(IDepartmentRepositoryInputData request, CancellationToken cancellationToken, Func<IDepartmentRepositoryInputData, CancellationToken, ValueTask<IDepartmentRepositoryOutputData>> next)
    {
        if (request is not FindAllDepartmentRepositoryInputData data)
        {
            return await next(request, cancellationToken);
        }

        var isCacheableOutputData = typeof(IDepartmentRepositoryOutputData).GetInterfaces().Contains(typeof(ICacheableRepositoryOutputData));
        var cacheKey = string.Empty;
        var expiry = TimeSpan.Zero;

        if (isCacheableOutputData)
        {
            var cacheableRepositoryOutputDataAttribute = (CacheableRepositoryOutputDataAttribute) Attribute.GetCustomAttribute(typeof(IFindAllDepartmentRepositoryOutputData), typeof(CacheableRepositoryOutputDataAttribute));
            cacheKey = cacheableRepositoryOutputDataAttribute.CacheKeyName;
            expiry = cacheableRepositoryOutputDataAttribute.Expiry;
            
            var cacheString = await CacheClient.HashGetAsync(cacheableRepositoryOutputDataAttribute.CacheKeyName);

            if (cacheString is not null)
            {
                return await HandleAsync(cacheString);
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