using UseCase.Departments.Common;

namespace UseCase.Departments.Dto;

public class ListDepartmentsUseCaseOutput : IDepartmentsUseCaseOutput
{
    public IEnumerable<Department>? Departments { get; set; }
}