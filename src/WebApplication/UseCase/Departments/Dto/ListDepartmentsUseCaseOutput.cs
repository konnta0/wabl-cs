using UseCase.Departments.Common;

namespace UseCase.Departments;

public class ListDepartmentsUseCaseOutput : IDepartmentsUseCaseOutput
{
    public IEnumerable<Department>? Departments { get; set; }
}