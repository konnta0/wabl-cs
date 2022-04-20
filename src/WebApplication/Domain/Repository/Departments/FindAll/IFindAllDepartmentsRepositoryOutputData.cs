using Domain.Entity.Employee;

namespace Domain.Repository.Departments.FindAll;

[CacheableRepositoryOutputDataAttribute(nameof(IFindAllDepartmentsRepositoryOutputData), TimeSpan.TicksPerMinute)]
public interface IFindAllDepartmentsRepositoryOutputData : IDepartmentsRepositoryOutputData
{ 
    IEnumerable<DepartmentEntity>? DepartmentsModels { get; init; }
}