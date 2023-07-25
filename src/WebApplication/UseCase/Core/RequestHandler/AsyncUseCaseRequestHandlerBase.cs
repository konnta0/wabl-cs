using Infrastructure.Core.Instrumentation.UseCase;
using MessagePipe;

namespace UseCase.Core.RequestHandler;

public abstract class AsyncUseCaseRequestHandlerBase<TInput> : IAsyncRequestHandler<IUseCaseInput, IUseCaseOutput?> where TInput : IUseCaseInput
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

        await ExecuteAsync(input, cancellationToken);

        var output = await CollectResponseAsync(input, cancellationToken);
        activity?.SetTag("OutputData", output);

        return output;
    }

    protected abstract ValueTask ValidateAsync(TInput input, CancellationToken cancellationToken = new());
    
    protected abstract ValueTask ExecuteAsync(TInput input, CancellationToken cancellationToken = new());
    
    protected abstract ValueTask<IUseCaseOutput> CollectResponseAsync(TInput input, CancellationToken cancellationToken = new());
}
