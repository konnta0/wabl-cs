using WebApplication.Application.Core.RepositoryHandler;
using MessagePipe;
using WebApplication.Domain.Repository;
using WebApplication.Infrastructure.Instrumentation.Repository;
using WebApplication.Infrastructure.Repository;

namespace WebApplication.Infrastructure.Core.RequestHandler;

public class RepositoryHandler(
    IAsyncRequestAllHandler<IRepositoryInput, IRepositoryOutput?> asyncRequestHandler,
    IRequestAllHandler<IRepositoryInput, IRepositoryOutput?> requestHandler,
    IRepositoryActivityStarter activityStarter,
    IRepositoryInputTypeResolver repositoryInputTypeResolver)
    : IRepositoryHandler
{
    public async ValueTask<TOutput> InvokeAsync<TInput, TOutput>(Action<TInput> inputFunc, CancellationToken cancellationToken = new ()) where TInput : IRepositoryInput where TOutput : IRepositoryOutput
    {
        var inputType = repositoryInputTypeResolver.Resolve<TInput>() ?? throw new InvalidOperationException($"Not found {typeof(TInput).Name}.");
        var input = (TInput)Activator.CreateInstance(inputType)! ?? throw new InvalidOperationException($"Not found {typeof(TInput).Name}.");
        inputFunc.Invoke(input);
        
        using var activity = activityStarter.Start();
        activity?.SetTag("inputType", typeof(TInput).Name);
        
        var results = await asyncRequestHandler.InvokeAllAsync(input, AsyncPublishStrategy.Parallel, cancellationToken);
        var result = results.Where(x => x is not null).OfType<TOutput>().FirstOrDefault();
        if (result is not null)
        {
            return result;
        }
        
        results = requestHandler.InvokeAll(input);
        result = results.Where(x => x is not null).OfType<TOutput>().FirstOrDefault();

        if (result is null)
        {
            throw new InvalidOperationException($"Not found {typeof(TOutput).Name}.");
        }
        
        return result;
        
    }
}