namespace Application.Core.RequestHandler;

public interface IUseCaseHandler
{
    ValueTask<TOutput> InvokeAsync<TInput, TOutput>(TInput input) where TOutput : IUseCaseOutput where TInput : IUseCaseInput;
}
