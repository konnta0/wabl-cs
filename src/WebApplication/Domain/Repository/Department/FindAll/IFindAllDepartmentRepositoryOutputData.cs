using Domain.Entity.Employee;

namespace Domain.Repository.Department.FindAll;

[CacheableRepositoryOutputData(nameof(IFindAllDepartmentRepositoryOutputData), TimeSpan.TicksPerMinute)]
public interface IFindAllDepartmentRepositoryOutputData : IDepartmentRepositoryOutputData
{ 
    IEnumerable<DepartmentEntity>? DepartmentsModels { get; init; }
}