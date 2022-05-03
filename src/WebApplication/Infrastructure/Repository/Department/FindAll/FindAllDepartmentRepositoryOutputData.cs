using Domain.Entity.Employee;
using Domain.Repository.Department.FindAll;

namespace Infrastructure.Repository.Department.FindAll;

public class FindAllDepartmentRepositoryOutputData : IFindAllDepartmentRepositoryOutputData
{
    public IEnumerable<DepartmentEntity>? DepartmentsModels { get; init; }
}