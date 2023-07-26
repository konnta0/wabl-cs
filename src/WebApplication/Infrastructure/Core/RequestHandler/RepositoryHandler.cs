using Domain.Repository;
using Infrastructure.Core.Instrumentation.Repository;
using MessagePipe;

namespace Infrastructure.Core.RequestHandler;

public class RepositoryHandler : IRepositoryHandler
{
    private readonly IAsyncRequestAllHandler<IRepositoryInput, IRepositoryOutput?> _asyncRequestHandler;
    private readonly IRequestAllHandler<IRepositoryInput, IRepositoryOutput?> _requestHandler;
    private readonly IRepositoryActivityStarter _activityStarter;
    
    public RepositoryHandler(
        IAsyncRequestAllHandler<IRepositoryInput, IRepositoryOutput?> asyncRequestHandler, 
        IRequestAllHandler<IRepositoryInput, IRepositoryOutput?> requestHandler, 
        IRepositoryActivityStarter activityStarter)
    {
        _asyncRequestHandler = asyncRequestHandler;
        _requestHandler = requestHandler;
        _activityStarter = activityStarter;
    }

    public async ValueTask<TOutput> InvokeAsync<TInput, TOutput>(TInput input, CancellationToken cancellationToken = new ()) where TInput : IRepositoryInput where TOutput : IRepositoryOutput
    {
        using var activity = _activityStarter.Start();
        activity?.SetTag("inputType", typeof(TInput).Name);
        
        var results = await _asyncRequestHandler.InvokeAllAsync(input, AsyncPublishStrategy.Parallel, cancellationToken);
        var result = results.Where(x => x is not null).OfType<TOutput>().FirstOrDefault();
        if (result is not null)
        {
            return result;
        }
        
        results = _requestHandler.InvokeAll(input);
        result = results.Where(x => x is not null).OfType<TOutput>().FirstOrDefault();

        if (result is null)
        {
            throw new InvalidOperationException($"Not found {typeof(TOutput).Name}.");
        }
        
        return result;
        
    }
}