using MessagePipe;

namespace WebApplication.Application.Core.RequestHandler;

internal abstract class AsyncUseCaseRequestHandlerBase<TInput, TExecuteResult> : IAsyncRequestHandler<IUseCaseInput, IUseCaseOutput?> where TInput : IUseCaseInput where TExecuteResult : IUseCaseExecuteResult
{
    protected AsyncUseCaseRequestHandlerBase(IUseCaseActivityStarter activityStarter)
    {
        ActivityStarter = activityStarter;
    }

    protected IUseCaseActivityStarter ActivityStarter { get; }

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
    
    protected abstract ValueTask<TExecuteResult> ExecuteAsync(TInput input, CancellationToken cancellationToken = new());
    
    protected abstract ValueTask<IUseCaseOutput> CollectResponseAsync(TInput input, TExecuteResult executeResult, CancellationToken cancellationToken = new());
}
