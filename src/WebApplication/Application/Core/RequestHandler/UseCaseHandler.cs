using MessagePipe;

namespace Application.Core.RequestHandler;

public sealed class UseCaseHandler : IUseCaseHandler
{
    private readonly IAsyncRequestAllHandler<IUseCaseInput, IUseCaseOutput?> _asyncRequestHandler;
    private readonly IRequestAllHandler<IUseCaseInput, IUseCaseOutput?> _requestHandler;
    private readonly IUseCaseActivityStarter _activityStarter;

    public UseCaseHandler(
        IAsyncRequestAllHandler<IUseCaseInput, IUseCaseOutput?> asyncRequestHandler,
        IRequestAllHandler<IUseCaseInput, IUseCaseOutput?> requestHandler, IUseCaseActivityStarter activityStarter)
    {
        _asyncRequestHandler = asyncRequestHandler;
        _requestHandler = requestHandler;
        _activityStarter = activityStarter;
    }
    
    public async ValueTask<TOutput> InvokeAsync<TInput, TOutput>(TInput input, CancellationToken cancellationToken = default) where TInput : IUseCaseInput where TOutput : IUseCaseOutput
    {
        using var activity = _activityStarter.Start();
        activity?.SetTag("InputType", typeof(TInput).Name);
        
        var results = await _asyncRequestHandler.InvokeAllAsync(input, AsyncPublishStrategy.Parallel, cancellationToken);
        var result = results.Where(static x => x is not null).OfType<TOutput>().FirstOrDefault();
        if (result is not null)
        {
            return result;
        }

        results = _requestHandler.InvokeAll(input);
        result = results.Where(static x => x is not null).OfType<TOutput>().FirstOrDefault();

        if (result is null)
        {
            throw new InvalidOperationException($"Not found {typeof(TOutput).Name}.");
        }
        
        return result;
    }
}