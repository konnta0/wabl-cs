using Domain.Model;
using Domain.Repository.Departments.FindAll;
using Infrastructure.Cache.Repository;

namespace Infrastructure.Repository.Departments.FindAll;

public class FindAllDepartmentsRepositoryOutputData : IFindAllDepartmentsRepositoryOutputData, ICacheableRepositoryOutputData
{
    public IEnumerable<DepartmentsModel> DepartmentsModels { get; init; }
}