using MessagePipe;

namespace WebApplication.Application.Core.RequestHandler;

internal abstract class AsyncUseCaseRequestHandlerBase<TInput, TExecutionResult>(IUseCaseActivityStarter activityStarter)
    : IAsyncRequestHandler<IUseCaseInput, IUseCaseOutput?>
    where TInput : IUseCaseInput
    where TExecutionResult : IUseCaseExecuteResult
{
    protected IUseCaseActivityStarter ActivityStarter { get; } = activityStarter;

    public async ValueTask<IUseCaseOutput?> InvokeAsync(IUseCaseInput request, CancellationToken cancellationToken = new ())
    {
        if (request is not TInput input)
        {
            return default;
        }
        using var activity = ActivityStarter.Start();
        activity?.SetTag("InputData", input);

        await ValidateAsync(input, cancellationToken);

        var result = await ExecuteAsync(input, cancellationToken);

        var output = await CollectResponseAsync(input, result, cancellationToken);
        activity?.SetTag("OutputData", output);

        return output;
    }

    protected abstract ValueTask ValidateAsync(TInput input, CancellationToken cancellationToken = new());
    
    protected abstract ValueTask<TExecutionResult> ExecuteAsync(TInput input, CancellationToken cancellationToken = new());
    
    protected abstract ValueTask<IUseCaseOutput> CollectResponseAsync(TInput input, TExecutionResult executionResult, CancellationToken cancellationToken = new());
}
