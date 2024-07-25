using MessagePipe;

namespace ManagementConsole.Application.RequestHandler;

public sealed class UseCaseHandler(
    IAsyncRequestAllHandler<IUseCaseInput, IUseCaseOutput?> asyncRequestHandler,
    IRequestAllHandler<IUseCaseInput, IUseCaseOutput?> requestHandler,
    IUseCaseActivityStarter activityStarter)
    : IUseCaseHandler
{
    public async ValueTask<TOutput> InvokeAsync<TInput, TOutput>(TInput input, CancellationToken cancellationToken = default) where TInput : IUseCaseInput where TOutput : IUseCaseOutput
    {
        using var activity = activityStarter.Start();
        activity?.SetTag("InputType", typeof(TInput).Name);
        
        var results = await asyncRequestHandler.InvokeAllAsync(input, AsyncPublishStrategy.Parallel, cancellationToken);
        var result = results.Where(static x => x is not null).OfType<TOutput>().FirstOrDefault();
        if (result is not null)
        {
            return result;
        }

        results = requestHandler.InvokeAll(input);
        result = results.Where(static x => x is not null).OfType<TOutput>().FirstOrDefault();

        if (result is null)
        {
            throw new InvalidOperationException($"Not found {typeof(TOutput).Name}.");
        }
        
        return result;
    }
}