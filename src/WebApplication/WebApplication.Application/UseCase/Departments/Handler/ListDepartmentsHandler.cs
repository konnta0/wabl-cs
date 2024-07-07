using WebApplication.Domain.Repository.Department;
using WebApplication.Application.Core.RepositoryHandler;
using WebApplication.Application.Core.RequestHandler;
using WebApplication.Application.Departments.Common;
using WebApplication.Application.UseCase.Departments.DataTransferObject;
using WebApplication.Application.UseCase.Departments.ExecutionResult;

namespace WebApplication.Application.UseCase.Departments;

internal class ListDepartmentsHandler(
    IUseCaseActivityStarter activityStarter,
    IRepositoryHandler repositoryHandler)
    : AsyncUseCaseRequestHandlerBase<ListDepartmentsUseCaseInput, ListDepartmentExecuteResult>(activityStarter)
{
    private ListDepartmentsUseCaseOutput _output = null!;

    protected override ValueTask ValidateAsync(ListDepartmentsUseCaseInput useCaseInput, CancellationToken cancellationToken = new ())
    {
        // nop
        return ValueTask.CompletedTask;
    }

    protected override async ValueTask<ListDepartmentExecuteResult> ExecuteAsync(ListDepartmentsUseCaseInput useCaseInput, CancellationToken cancellationToken = new ())
    {
        _output = new ListDepartmentsUseCaseOutput();
        
        var repositoryOutputData = await repositoryHandler.InvokeAsync<IFindAllInput, IFindAllOutput>(
            _ => {}, cancellationToken);

        _output.Departments = repositoryOutputData.DepartmentsEntities!
            .SelectMany(static x => new[] { new Department { DepotNo = x.DepotNo, DeptName = x.DeptName } });
        return new ListDepartmentExecuteResult();
    }

    protected override ValueTask<IUseCaseOutput> CollectResponseAsync(
        ListDepartmentsUseCaseInput useCaseInput,
        ListDepartmentExecuteResult executionResult,
        CancellationToken cancellationToken = new ())
    {
        return _output is null ? throw new NullReferenceException() : new ValueTask<IUseCaseOutput>(_output);
    }
}