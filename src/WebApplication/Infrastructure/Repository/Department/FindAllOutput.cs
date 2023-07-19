using Domain.Entity.Employee;
using Domain.Repository.Department;

namespace Infrastructure.Repository.Department;

public class FindAllOutput : IFindAllOutput
{
    public IEnumerable<DepartmentEntity>? DepartmentsEntities { get; init; }
}