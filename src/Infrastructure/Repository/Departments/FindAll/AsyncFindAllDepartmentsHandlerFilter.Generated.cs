using Infrastructure.Core.RequestHandler;
using MessagePipe;

namespace Infrastructure.Repository.Departments.FindAll;

internal partial class AsyncFindAllDepartmentsHandlerFilter : AsyncRequestHandlerFilter<IDepartmentsRepositoryInputData, IDepartmentsRepositoryOutputData>, IAsyncRepositoryHandlerFilter<FindAllDepartmentsRepositoryInputData, FindAllDepartmentsRepositoryOutputData>
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