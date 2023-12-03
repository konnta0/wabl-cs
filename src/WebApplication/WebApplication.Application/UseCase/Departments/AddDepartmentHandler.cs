using Domain.Repository.Department;
using WebApplication.Application.Core.Exception;
using WebApplication.Application.Core.RepositoryHandler;
using WebApplication.Application.Core.RequestHandler;
using WebApplication.Application.UseCase.Departments.Dto;
using WebApplication.Application.UseCase.Departments.ExecuteResult;

namespace WebApplication.Application.UseCase.Departments;

internal class AddDepartmentHandler : AsyncUseCaseRequestHandlerBase<AddDepartmentsUseCaseInput, AddDepartmentExecuteResult>
{
    private readonly IRepositoryHandler _repositoryHandler;

    public AddDepartmentHandler(IUseCaseActivityStarter activityStarter, IRepositoryHandler repositoryHandler) : base(activityStarter)
    {
        _repositoryHandler = repositoryHandler;
    }

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
        _ = await _repositoryHandler.InvokeAsync<IAddInput, IAddOutput>(addInput =>
        {
            addInput.DepotNo = input.DepotNo;
            addInput.DeptName = input.DeptName;
        }, cancellationToken);
        
        return new AddDepartmentExecuteResult();
    }

    protected override ValueTask<IUseCaseOutput> CollectResponseAsync(
        AddDepartmentsUseCaseInput input,
        AddDepartmentExecuteResult executeResult,
        CancellationToken cancellationToken = new ())
    {
        var output = new AddDepartmentsUseCaseOutput();
        return ValueTask.FromResult((IUseCaseOutput)output);
    }
}