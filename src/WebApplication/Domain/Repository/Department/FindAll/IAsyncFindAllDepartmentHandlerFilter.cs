namespace Domain.Repository.Department.FindAll;

public interface IAsyncFindAllDepartmentHandlerFilter
{
    ValueTask<IFindAllDepartmentRepositoryOutputData> HandleAsync(
        IFindAllDepartmentRepositoryInputData repositoryInputData);
}