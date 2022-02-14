using Domain.Repository.Departments;
using Domain.Repository.Departments.FindAll;
using Infrastructure.Cache.Repository;
using Infrastructure.Core.RequestHandler;
using MessagePipe;

namespace Infrastructure.Repository.Departments.FindAll;

internal partial class AsyncFindAllDepartmentsHandlerFilter : AsyncRequestHandlerFilter<IDepartmentsRepositoryInputData, IDepartmentsRepositoryOutputData>, IAsyncRepositoryHandlerFilter<IFindAllDepartmentsRepositoryInputData, IFindAllDepartmentsRepositoryOutputData>
{
    public override async ValueTask<IDepartmentsRepositoryOutputData> InvokeAsync(IDepartmentsRepositoryInputData request, CancellationToken cancellationToken, Func<IDepartmentsRepositoryInputData, CancellationToken, ValueTask<IDepartmentsRepositoryOutputData>> next)
    {
        if (request is not FindAllDepartmentsRepositoryInputData data)
        {
            return await next(request, cancellationToken);
        }

        return await HandleAsync(data);
    }
}