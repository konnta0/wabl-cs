using Infrastructure.Core.RequestHandler;
using Infrastructure.Repository.Departments.FindAll;
using MessagePipe;
using UseCase.Departments.Common;

namespace UseCase.Departments.List;

internal partial class AsyncListDepartmentsUseCaseHandlerFilter
{
    private readonly IAsyncRequestHandler<Infrastructure.Repository.Departments.IDepartmentsInputData, Infrastructure.Repository.Departments.IDepartmentsOutputData> _departmentsRepositoryHandler;
    
    public AsyncListDepartmentsUseCaseHandlerFilter(
        IAsyncRequestHandler<Infrastructure.Repository.Departments.IDepartmentsInputData,
            Infrastructure.Repository.Departments.IDepartmentsOutputData> departmentsRepositoryHandler)
    {
        _departmentsRepositoryHandler = departmentsRepositoryHandler;
    }

    public async ValueTask<ListDepartmentsOutputData> HandleAsync(ListDepartmentsInputData inputData)
    {
        var outputData = new ListDepartmentsOutputData();
        
        var repositoryOutputData = (FindAllDepartmentsOutputData) await _departmentsRepositoryHandler.InvokeAsync(new FindAllDepartmentsInputData());
        
        outputData.Departments = repositoryOutputData.DepartmentsModels.SelectMany(x => new[]
            { new Department { DepotNo = x.DepotNo, DeptName = x.DeptName } });
        return outputData;
    }
}