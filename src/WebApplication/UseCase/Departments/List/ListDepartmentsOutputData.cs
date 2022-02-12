using UseCase.Departments.Common;

namespace UseCase.Departments.List;

public class ListDepartmentsOutputData : IDepartmentsOutputData
{
    public IEnumerable<Department> Departments { get; set; }
}