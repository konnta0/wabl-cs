using WebApplication.Application.Core.RepositoryHandler;
using MessagePipe;
using WebApplication.Domain.Repository;
using WebApplication.Infrastructure.Core.Instrumentation.Repository;
using WebApplication.Infrastructure.Repository;

namespace WebApplication.Infrastructure.Core.RequestHandler;

public class RepositoryHandler : IRepositoryHandler
{
    private readonly IAsyncRequestAllHandler<IRepositoryInput, IRepositoryOutput?> _asyncRequestHandler;
    private readonly IRequestAllHandler<IRepositoryInput, IRepositoryOutput?> _requestHandler;
    private readonly IRepositoryActivityStarter _activityStarter;
    private readonly IRepositoryInputTypeResolver _repositoryInputTypeResolver;
    
    public RepositoryHandler(
        IAsyncRequestAllHandler<IRepositoryInput, IRepositoryOutput?> asyncRequestHandler, 
        IRequestAllHandler<IRepositoryInput, IRepositoryOutput?> requestHandler, 
        IRepositoryActivityStarter activityStarter, IRepositoryInputTypeResolver repositoryInputTypeResolver)
    {
        _asyncRequestHandler = asyncRequestHandler;
        _requestHandler = requestHandler;
        _activityStarter = activityStarter;
        _repositoryInputTypeResolver = repositoryInputTypeResolver;
    }

    public async ValueTask<TOutput> InvokeAsync<TInput, TOutput>(Action<TInput> inputFunc, CancellationToken cancellationToken = new ()) where TInput : IRepositoryInput where TOutput : IRepositoryOutput
    {
        var inputType = _repositoryInputTypeResolver.Resolve<TInput>() ?? throw new InvalidOperationException($"Not found {typeof(TInput).Name}.");
        var input = (TInput)Activator.CreateInstance(inputType)! ?? throw new InvalidOperationException($"Not found {typeof(TInput).Name}.");
        inputFunc.Invoke(input);
        
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