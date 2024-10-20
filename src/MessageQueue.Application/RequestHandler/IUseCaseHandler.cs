namespace MessageQueue.Application.RequestHandler;

public interface IUseCaseHandler
{
    ValueTask<TOutput> InvokeAsync<TInput, TOutput>(TInput input, CancellationToken cancellationToken = default) where TOutput : IUseCaseOutput where TInput : IUseCaseInput;
}
