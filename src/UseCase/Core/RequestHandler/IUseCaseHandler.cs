using MessagePipe;

namespace UseCase.Core.RequestHandler;

public interface IUseCaseHandler<in TInput, out TOut> where TInput : IInputData where TOut : IOutputData, IRequestHandler<TInput, TOut>
{
}