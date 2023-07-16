using Domain.Repository.Department;
using Infrastructure.Core.Instrumentation.UseCase;
using Infrastructure.Core.RequestHandler;
using Infrastructure.Repository.Department;
using UseCase.Core.RequestHandler;
using UseCase.Departments.Common;

namespace UseCase.Departments.List;

internal class ListDepartmentsHandler : AsyncUseCaseRequestHandlerBase<ListDepartmentsUseCaseInput>
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

    protected override async ValueTask ExecuteAsync(ListDepartmentsUseCaseInput useCaseInput, CancellationToken cancellationToken = new ())
    {
        _output = new ListDepartmentsUseCaseOutput();
        
        var repositoryOutputData = await _repositoryHandler.InvokeAsync<FindAllInput, FindAllOutput>(new FindAllInput(), cancellationToken);

        _output.Departments = repositoryOutputData.DepartmentsEntities!.SelectMany(x => new[]
            { new Department { DepotNo = x.DepotNo, DeptName = x.DeptName } });
    }

    protected override ValueTask<IUseCaseOutput> CollectResponseAsync(ListDepartmentsUseCaseInput useCaseInput,
        CancellationToken cancellationToken = new ())
    {
        return _output is null ? throw new NullReferenceException() : new ValueTask<IUseCaseOutput>(_output);
    }
}