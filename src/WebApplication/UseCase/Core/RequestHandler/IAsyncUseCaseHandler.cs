using MessagePipe;

namespace UseCase.Core.RequestHandler;

public interface IAsyncUseCaseHandler<in TInput, TOut> : IAsyncRequestHandler<TInput, TOut> where TInput : IInputData where TOut : IOutputData
{
}
