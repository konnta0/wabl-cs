using Application.Core.RequestHandler;
using Application.Departments.Common;
using Application.Departments.Dto;
using Application.Departments.ExecuteResult;
using Infrastructure.Core.Instrumentation.UseCase;
using Infrastructure.Core.RequestHandler;
using Infrastructure.Repository.Department;

namespace Application.Departments;

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
        
        var repositoryOutputData = await _repositoryHandler.InvokeAsync<FindAllInput, FindAllOutput>(new FindAllInput(), cancellationToken);

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