using WebApplication.Application.Departments.Common;
using WebApplication.Application.UseCase.Departments.Dto;

namespace WebApplication.Application.Departments.Dto;

public class ListDepartmentsUseCaseOutput : IDepartmentsUseCaseOutput
{
    public IEnumerable<Department>? Departments { get; set; }
}