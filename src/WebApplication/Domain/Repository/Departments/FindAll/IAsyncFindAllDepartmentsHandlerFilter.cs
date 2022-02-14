namespace Domain.Repository.Departments.FindAll;

public interface IAsyncFindAllDepartmentsHandlerFilter
{
    ValueTask<IFindAllDepartmentsRepositoryOutputData> HandleAsync(
        IFindAllDepartmentsRepositoryInputData repositoryInputData);
}