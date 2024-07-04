using WebApplication.Application.Departments.Common;

namespace WebApplication.Application.UseCase.Departments.DataTransferObject;

public class ListDepartmentsUseCaseOutput : IDepartmentsUseCaseOutput
{
    public IEnumerable<Department>? Departments { get; set; }
}