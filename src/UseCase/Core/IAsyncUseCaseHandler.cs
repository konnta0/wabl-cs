using MessagePipe;

namespace UseCase.Core;

public interface IAyncUseCaseHandler<in TInput, out TOut> where TInput : IInputData where TOut : IOutputData, IRequestHandler<TInput, TOut>
{
}
