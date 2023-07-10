using UseCase.Departments.Common;

namespace UseCase.Departments;

public class ListDepartmentsOutputData : IDepartmentsOutputData
{
    public IEnumerable<Department>? Departments { get; set; }
}