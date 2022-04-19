using Domain.Entity.Employee;
using Domain.Repository.Departments.FindAll;

namespace Infrastructure.Repository.Departments.FindAll;

public class FindAllDepartmentsRepositoryOutputData : IFindAllDepartmentsRepositoryOutputData
{
    public IEnumerable<DepartmentModel>? DepartmentsModels { get; init; }
}