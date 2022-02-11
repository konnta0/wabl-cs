using Domain.Model;

namespace Infrastructure.Repository.Departments.FindAll;

public class FindAllDepartmentsRepositoryOutputData : IDepartmentsRepositoryOutputData
{
    public IEnumerable<DepartmentsModel> DepartmentsModels { get; init; }
}