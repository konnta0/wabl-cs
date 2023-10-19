using Application.Departments.Common;
using Application.UseCase.Departments.Dto;

namespace Application.Departments.Dto;

public class ListDepartmentsUseCaseOutput : IDepartmentsUseCaseOutput
{
    public IEnumerable<Department>? Departments { get; set; }
}