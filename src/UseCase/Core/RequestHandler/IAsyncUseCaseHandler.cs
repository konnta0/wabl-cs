using MessagePipe;

namespace UseCase.Core.RequestHandler;

public interface IAyncUseCaseHandler<in TInput, out TOut> where TInput : IInputData where TOut : IOutputData, IRequestHandler<TInput, TOut>
{
}
