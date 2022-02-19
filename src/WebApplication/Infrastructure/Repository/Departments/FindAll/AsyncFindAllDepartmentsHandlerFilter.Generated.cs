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

        var isCacheableOutputData = typeof(IDepartmentsRepositoryOutputData) is ICacheableRepositoryOutputData;
        var cacheKey = string.Empty;
        var expiry = TimeSpan.Zero;

        if (isCacheableOutputData)
        {
            var cacheableRepositoryOutputDataAttribute = (CacheableRepositoryOutputDataAttribute) Attribute.GetCustomAttribute(typeof(IDepartmentsRepositoryOutputData), typeof(CacheableRepositoryOutputDataAttribute));
            return await CacheClient.HashGetAsync<IDepartmentsRepositoryOutputData>(cacheableRepositoryOutputDataAttribute.CacheKeyName);
        }

        var handleResponse = await HandleAsync(data);

        if (isCacheableOutputData)
        {
            var cacheableRepositoryOutputDataAttribute = (CacheableRepositoryOutputDataAttribute) Attribute.GetCustomAttribute(typeof(IDepartmentsRepositoryOutputData), typeof(CacheableRepositoryOutputDataAttribute));
            await CacheClient.HashSetAsync(cacheableRepositoryOutputDataAttribute.CacheKeyName, handleResponse);
        }

        return handleResponse;
    }
}

internal interface ICacheableRepositoryFilter : IDisposable
{
    ICacheClient CacheClient { get; set; }
}