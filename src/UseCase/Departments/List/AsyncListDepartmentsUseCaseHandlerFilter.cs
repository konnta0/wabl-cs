using Infrastructure.Repository.Departments.FindAll;
using MessagePipe;
using UseCase.Departments.Common;

namespace UseCase.Departments.List;

internal partial class AsyncListDepartmentsUseCaseHandlerFilter
{
    private readonly IAsyncRequestHandler<Infrastructure.Repository.Departments.IDepartmentsRepositoryInputData, Infrastructure.Repository.Departments.IDepartmentsRepositoryOutputData> _departmentsRepositoryHandler;
    
    public AsyncListDepartmentsUseCaseHandlerFilter(
        IAsyncRequestHandler<Infrastructure.Repository.Departments.IDepartmentsRepositoryInputData,
            Infrastructure.Repository.Departments.IDepartmentsRepositoryOutputData> departmentsRepositoryHandler)
    {
        _departmentsRepositoryHandler = departmentsRepositoryHandler;
    }

    public async ValueTask<ListDepartmentsOutputData> HandleAsync(ListDepartmentsInputData inputData)
    {
        var outputData = new ListDepartmentsOutputData();
        
        var repositoryOutputData = (FindAllDepartmentsRepositoryOutputData) await _departmentsRepositoryHandler.InvokeAsync(new FindAllDepartmentsRepositoryInputData());
        
        outputData.Departments = repositoryOutputData.DepartmentsModels.SelectMany(x => new[]
            { new Department { DepotNo = x.DepotNo, DeptName = x.DeptName } });
        return outputData;
    }
}