using Infrastructure.Core.Instrumentation.UseCase;
using Infrastructure.Core.RequestHandler;
using Infrastructure.Repository.Department;
using UseCase.Core.Exception;
using UseCase.Core.RequestHandler;
using UseCase.Departments.Dto;

namespace UseCase.Departments;

public class AddDepartmentHandler : AsyncUseCaseRequestHandlerBase<AddDepartmentsUseCaseInput>
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

    protected override async ValueTask ExecuteAsync(AddDepartmentsUseCaseInput input, CancellationToken cancellationToken = new ())
    {
        _ = await _repositoryHandler.InvokeAsync<AddInput, AddOutput>(new AddInput
        {
            DepotNo = input.DepotNo,
            DeptName = input.DeptName
        }, cancellationToken);
    }

    protected override ValueTask<IUseCaseOutput> CollectResponseAsync(AddDepartmentsUseCaseInput input,
        CancellationToken cancellationToken = new ())
    {
        var output = new AddDepartmentsUseCaseOutput();
        return ValueTask.FromResult((IUseCaseOutput)output);
    }
}