using Domain.Repository;
using UseCase.Core.RequestHandler;
using UseCase.Departments.Common;

namespace UseCase.Departments.List;

internal partial class AsyncListDepartmentsUseCaseHandler : AsyncInternalUseCaseHandler<IDepartmentsInputData, IDepartmentsOutputData>, IAsyncInternalUseCaseHandler<ListDepartmentsInputData, ListDepartmentsOutputData>
{
    private readonly IDepartmentsRepository _departmentsRepository;

    public AsyncListDepartmentsUseCaseHandler(IDepartmentsRepository departmentsRepository)
    {
        _departmentsRepository = departmentsRepository;
    }
    
    public override async ValueTask<IDepartmentsOutputData> InvokeAsync(IDepartmentsInputData request, CancellationToken cancellationToken, Func<IDepartmentsInputData, CancellationToken, ValueTask<IDepartmentsOutputData>> next)
    {
        if (request is not ListDepartmentsInputData data)
        {
            return await next(request, cancellationToken);
        }

        return await HandleAsync(data);
    }

    public async ValueTask<ListDepartmentsOutputData> HandleAsync(ListDepartmentsInputData inputData)
    {
        var outputData = new ListDepartmentsOutputData();
        var departmentsModels = await _departmentsRepository.FindAllAsync();
        outputData.Departments = departmentsModels.SelectMany(x => new[]
            { new Department { DepotNo = x.DepotNo, DeptName = x.DeptName } });
        return outputData;
    }
}