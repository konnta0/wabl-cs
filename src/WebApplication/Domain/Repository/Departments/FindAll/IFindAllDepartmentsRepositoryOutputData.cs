using Domain.Model;
using Domain.Model.Employees;

namespace Domain.Repository.Departments.FindAll;

[CacheableRepositoryOutputDataAttribute(nameof(IFindAllDepartmentsRepositoryOutputData), TimeSpan.TicksPerMinute)]
public interface IFindAllDepartmentsRepositoryOutputData : IDepartmentsRepositoryOutputData
{ 
    IEnumerable<DepartmentModel>? DepartmentsModels { get; init; }
}