namespace Domain.Repository.Departments.FindAll;

public interface IAsyncFindAllDepartmentsHandlerFilter
{
    ValueTask<FindAllDepartmentsRepositoryOutputData> HandleAsync(
        FindAllDepartmentsRepositoryInputData repositoryInputData);
}