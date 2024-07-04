using WebApplication.Domain.Repository.Department;
using WebApplication.Application.Core.RepositoryHandler;
using WebApplication.Application.Core.RequestHandler;
using WebApplication.Application.Departments.Common;
using WebApplication.Application.UseCase.Departments.DataTransferObject;
using WebApplication.Application.UseCase.Departments.ExecuteResult;

namespace WebApplication.Application.UseCase.Departments;

internal class ListDepartmentsHandler : AsyncUseCaseRequestHandlerBase<ListDepartmentsUseCaseInput, ListDepartmentExecuteResult>
{
    private readonly IRepositoryHandler _repositoryHandler;
    private ListDepartmentsUseCaseOutput _output = null!;

    public ListDepartmentsHandler(
        IUseCaseActivityStarter activityStarter, 
        IRepositoryHandler repositoryHandler) : base(activityStarter)
    {
        _repositoryHandler = repositoryHandler;
    }
    
    protected override ValueTask ValidateAsync(ListDepartmentsUseCaseInput useCaseInput, CancellationToken cancellationToken = new ())
    {
        // nop
        return ValueTask.CompletedTask;
    }

    protected override async ValueTask<ListDepartmentExecuteResult> ExecuteAsync(ListDepartmentsUseCaseInput useCaseInput, CancellationToken cancellationToken = new ())
    {
        _output = new ListDepartmentsUseCaseOutput();
        
        var repositoryOutputData = await _repositoryHandler.InvokeAsync<IFindAllInput, IFindAllOutput>(
            _ => {}, cancellationToken);

        _output.Departments = repositoryOutputData.DepartmentsEntities!
            .SelectMany(static x => new[] { new Department { DepotNo = x.DepotNo, DeptName = x.DeptName } });
        return new ListDepartmentExecuteResult();
    }

    protected override ValueTask<IUseCaseOutput> CollectResponseAsync(
        ListDepartmentsUseCaseInput useCaseInput,
        ListDepartmentExecuteResult executeResult,
        CancellationToken cancellationToken = new ())
    {
        return _output is null ? throw new NullReferenceException() : new ValueTask<IUseCaseOutput>(_output);
    }
}