using Domain.Model;

namespace Domain.Repository.Departments.FindAll;

public interface IFindAllDepartmentsRepositoryOutputData : IDepartmentsRepositoryOutputData
{ 
    IEnumerable<DepartmentsModel> DepartmentsModels { get; init; }
}