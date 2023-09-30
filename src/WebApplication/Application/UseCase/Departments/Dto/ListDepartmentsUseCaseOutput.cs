using Application.Departments.Common;

namespace Application.Departments.Dto;

public class ListDepartmentsUseCaseOutput : IDepartmentsUseCaseOutput
{
    public IEnumerable<Department>? Departments { get; set; }
}