namespace UseCase.Core.RequestHandler;

public interface IUseCaseHandler
{
    ValueTask<TOutput> InvokeAsync<TInput, TOutput>(TInput input) where TOutput : IOutputData where TInput : IInputData;
}
