using Domain.Repository;
using MessagePipe;
using UseCase.Core.RequestHandler;
using UseCase.Departments.Common;

namespace UseCase.Departments.List;

internal partial class AsyncListDepartmentsUseCaseHandlerFilter : AsyncRequestHandlerFilter<IDepartmentsInputData, IDepartmentsOutputData>, IAsyncUseCaseHandlerFilter<ListDepartmentsInputData, ListDepartmentsOutputData>
{
    public override async ValueTask<IDepartmentsOutputData> InvokeAsync(IDepartmentsInputData request, CancellationToken cancellationToken, Func<IDepartmentsInputData, CancellationToken, ValueTask<IDepartmentsOutputData>> next)
    {
        if (request is not ListDepartmentsInputData data)
        {
            return await next(request, cancellationToken);
        }

        return await HandleAsync(data);
    }
}