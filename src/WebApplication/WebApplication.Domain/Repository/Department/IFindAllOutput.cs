using WebApplication.Domain.Entity.Employee;
using WebApplication.Domain.Repository.Department.Core;

namespace WebApplication.Domain.Repository.Department;

public interface IFindAllOutput : IDepartmentRepositoryOutput
{ 
    IEnumerable<DepartmentEntity>? DepartmentsEntities { get; init; }
}