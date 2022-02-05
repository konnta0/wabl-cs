using Infrastructure.Core.RequestHandler;
using MessagePipe;

namespace Infrastructure.Repository.Departments.FindAll;

internal partial class AsyncFindAllDepartmentsHandlerFilter : AsyncRequestHandlerFilter<IDepartmentsInputData, IDepartmentsOutputData>, IAsyncRepositoryHandlerFilter<FindAllDepartmentsInputData, FindAllDepartmentsOutputData>
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