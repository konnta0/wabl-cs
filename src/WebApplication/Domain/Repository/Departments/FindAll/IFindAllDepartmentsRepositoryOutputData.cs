using Domain.Model;

namespace Domain.Repository.Departments.FindAll;

[CacheableRepositoryOutputDataAttribute(nameof(IFindAllDepartmentsRepositoryOutputData), TimeSpan.TicksPerMinute)]
public interface IFindAllDepartmentsRepositoryOutputData : IDepartmentsRepositoryOutputData
{ 
    IEnumerable<DepartmentsModel>? DepartmentsModels { get; init; }
}