using Domain.Model;

namespace Infrastructure.Repository.Departments.FindAll;

public class FindAllDepartmentsOutputData : IDepartmentsOutputData
{
    public IEnumerable<DepartmentsModel> DepartmentsModels { get; init; }
}