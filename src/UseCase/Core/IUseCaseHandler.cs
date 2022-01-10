using MessagePipe;

namespace UseCase.Core;

public interface IUseCaseHandler<in TInput, out TOut> where TInput : IInputData where TOut : IOutputData, IRequestHandler<TInput, TOut>
{
}