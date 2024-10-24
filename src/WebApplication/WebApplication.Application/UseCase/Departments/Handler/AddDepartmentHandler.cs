using WebApplication.Application.Core.Exception;
using WebApplication.Application.Core.RepositoryHandler;
using WebApplication.Application.Core.RequestHandler;
using WebApplication.Application.UseCase.Departments.DataTransferObject;
using WebApplication.Application.UseCase.Departments.ExecutionResult;
using WebApplication.Domain.Repository.Department;

namespace WebApplication.Application.UseCase.Departments.Handler;

internal class AddDepartmentHandler(IUseCaseActivityStarter activityStarter, IRepositoryHandler repositoryHandler)
    : AsyncUseCaseRequestHandlerBase<AddDepartmentsUseCaseInput, AddDepartmentExecuteResult>(activityStarter)
{
    protected override ValueTask ValidateAsync(AddDepartmentsUseCaseInput input,
        CancellationToken cancellationToken = new ())
    {
        if (input.DepotNo is null)
            throw new BadRequestException(nameof(input.DepotNo));
        if (input.DeptName is null)
            throw new BadRequestException(nameof(input.DeptName));

        return ValueTask.CompletedTask;
    }

    protected override async ValueTask<AddDepartmentExecuteResult> ExecuteAsync(AddDepartmentsUseCaseInput input, CancellationToken cancellationToken = new ())
    {
        _ = await repositoryHandler.InvokeAsync<IAddInput, IAddOutput>(addInput =>
        {
            addInput.DepotNo = input.DepotNo;
            addInput.DeptName = input.DeptName;
        }, cancellationToken);
        
        return new AddDepartmentExecuteResult();
    }

    protected override ValueTask<IUseCaseOutput> CollectResponseAsync(
        AddDepartmentsUseCaseInput input,
        AddDepartmentExecuteResult executionResult,
        CancellationToken cancellationToken = new ())
    {
        var output = new AddDepartmentsUseCaseOutput();
        return ValueTask.FromResult((IUseCaseOutput)output);
    }
}