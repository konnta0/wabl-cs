using MessagePipe;

namespace MessageQueue.Application.RequestHandler;

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

        await ValidateAsync(input, cancellationToken);

        var result = await ExecuteAsync(input, cancellationToken);

        var output = await CollectResponseAsync(input, result, cancellationToken);

        return output;
    }

    protected abstract ValueTask ValidateAsync(TInput input, CancellationToken cancellationToken = new());
    
    protected abstract ValueTask<TExecutionResult> ExecuteAsync(TInput input, CancellationToken cancellationToken = new());
    
    protected abstract ValueTask<IUseCaseOutput> CollectResponseAsync(TInput input, TExecutionResult executionResult, CancellationToken cancellationToken = new());
}
