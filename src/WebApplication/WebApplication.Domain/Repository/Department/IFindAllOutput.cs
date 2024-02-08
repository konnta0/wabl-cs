using WebApplication.Domain.Entity.Employee;

namespace WebApplication.Domain.Repository.Department;

public interface IFindAllOutput : IDepartmentRepositoryOutput
{ 
    IEnumerable<DepartmentEntity>? DepartmentsEntities { get; init; }
}