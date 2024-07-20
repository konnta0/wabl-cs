using Shared.Domain.Entity.Employee;
using WebApplication.Domain.Repository.Department;

namespace WebApplication.Infrastructure.Repository.Department;

public class FindAllOutput : IFindAllOutput
{
    public IEnumerable<DepartmentEntity>? DepartmentsEntities { get; init; }
}