using Domain.Repository;
using UseCase.Departments.Common;

namespace UseCase.Departments.List;

internal partial class AsyncListDepartmentsUseCaseHandlerFilter
{
    private readonly IDepartmentsRepository _departmentsRepository;

    public AsyncListDepartmentsUseCaseHandlerFilter(IDepartmentsRepository departmentsRepository)
    {
        _departmentsRepository = departmentsRepository;
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