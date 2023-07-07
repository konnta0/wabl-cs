using MessagePipe;

namespace UseCase.Core.RequestHandler;

public sealed class UseCaseHandler : IUseCaseHandler
{
    private readonly IAsyncRequestAllHandler<IInputData, IOutputData?> _asyncRequestHandler;
    private readonly IRequestAllHandler<IInputData, IOutputData?> _requestHandler;

    public UseCaseHandler(
        IAsyncRequestAllHandler<IInputData, IOutputData?> asyncRequestHandler,
        IRequestAllHandler<IInputData, IOutputData?> requestHandler)
    {
        _asyncRequestHandler = asyncRequestHandler;
        _requestHandler = requestHandler;
    }
    
    public async ValueTask<TOutput> InvokeAsync<TInput, TOutput>(TInput input) where TInput : IInputData where TOutput : IOutputData
    {
        var results = await _asyncRequestHandler.InvokeAllAsync(input, AsyncPublishStrategy.Parallel);
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