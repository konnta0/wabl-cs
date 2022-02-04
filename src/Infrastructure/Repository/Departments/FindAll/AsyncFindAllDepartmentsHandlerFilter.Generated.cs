using Infrastructure.Core.RequestHandler;

namespace Infrastructure.Repository.Departments.FindAll;

internal partial class AsyncFindAllDepartmentsHandlerFilter : AsyncInternalRepositoryHandlerFilter<IDepartmentsInputData, IDepartmentsOutputData>, IAsyncInternalRepositoryHandler<FindAllDepartmentsInputData, FindAllDepartmentsOutputData>
{
    public override async ValueTask<IDepartmentsOutputData> InvokeAsync(IDepartmentsInputData request, CancellationToken cancellationToken, Func<IDepartmentsInputData, CancellationToken, ValueTask<IDepartmentsOutputData>> next)
    {
        if (request is not FindAllDepartmentsInputData data)
        {
            return await next(request, cancellationToken);
        }

        return await HandleAsync(data);
    }
}