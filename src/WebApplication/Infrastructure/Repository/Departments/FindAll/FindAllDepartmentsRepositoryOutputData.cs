using Domain.Model;
using Domain.Model.Employees;
using Domain.Repository.Departments.FindAll;

namespace Infrastructure.Repository.Departments.FindAll;

public class FindAllDepartmentsRepositoryOutputData : IFindAllDepartmentsRepositoryOutputData
{
    public IEnumerable<DepartmentsModel>? DepartmentsModels { get; init; }
}