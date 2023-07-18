using Domain.Entity.Employee;

namespace Domain.Repository.Department;

public interface IFindAllOutput : IDepartmentRepositoryOutput
{ 
    IEnumerable<DepartmentEntity>? DepartmentsEntities { get; init; }
}