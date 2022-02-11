using Domain.Model;

namespace Domain.Repository.Departments.FindAll;

public class FindAllDepartmentsRepositoryOutputData : IDepartmentsRepositoryOutputData
{
    public IEnumerable<DepartmentsModel> DepartmentsModels { get; init; }
}