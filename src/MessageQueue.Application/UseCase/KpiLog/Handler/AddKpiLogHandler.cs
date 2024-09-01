using MessageQueue.Application.RequestHandler;
using MessageQueue.Application.UseCase.KpiLog.DataTransferObject;
using MessageQueue.Application.UseCase.KpiLog.ExecutionResult;

namespace MessageQueue.Application.UseCase.KpiLog.Handler;

internal sealed class AddKpiLogHandler (IUseCaseActivityStarter activityStarter)
    : AsyncUseCaseRequestHandlerBase<AddKpiLogUseCaseInput, AddKpiLogExecutionResult>(activityStarter)
{
    protected override ValueTask ValidateAsync(AddKpiLogUseCaseInput input, CancellationToken cancellationToken = new ())
    {
        throw new NotImplementedException();
    }

    protected override ValueTask<AddKpiLogExecutionResult> ExecuteAsync(AddKpiLogUseCaseInput input, CancellationToken cancellationToken = new ())
    {
        using var activity = ActivityStarter.Start();

        return new ValueTask<AddKpiLogExecutionResult>();
    }

    protected override ValueTask<IUseCaseOutput> CollectResponseAsync(AddKpiLogUseCaseInput input, AddKpiLogExecutionResult executionResult,
        CancellationToken cancellationToken = new ())
    {
        throw new NotImplementedException();
    }
}