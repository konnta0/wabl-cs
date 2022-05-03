using Domain.Repository.Department;
using Infrastructure.Repository.Department.FindAll;
using MessagePipe;
using UseCase.Departments.Common;

namespace UseCase.Departments.List;

internal partial class AsyncListDepartmentsUseCaseHandlerFilter
{
    private readonly IAsyncRequestHandler<IDepartmentRepositoryInputData, IDepartmentRepositoryOutputData> _departmentsRepositoryHandler;
    
    public AsyncListDepartmentsUseCaseHandlerFilter(
        IAsyncRequestHandler<IDepartmentRepositoryInputData,
            IDepartmentRepositoryOutputData> departmentsRepositoryHandler)
    {
        _departmentsRepositoryHandler = departmentsRepositoryHandler;
    }

    public async ValueTask<ListDepartmentsOutputData> HandleAsync(ListDepartmentsInputData inputData)
    {
        var outputData = new ListDepartmentsOutputData();
        
        var repositoryOutputData = (FindAllDepartmentRepositoryOutputData) await _departmentsRepositoryHandler.InvokeAsync(new FindAllDepartmentRepositoryInputData());
        
        outputData.Departments = repositoryOutputData.DepartmentsModels!.SelectMany(x => new[]
            { new Department { DepotNo = x.DepotNo, DeptName = x.DeptName } });
        return outputData;
    }
}