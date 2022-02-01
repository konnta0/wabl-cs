using MessagePipe;

namespace UseCase.Core.RequestHandler;

internal abstract class InternalUseCaseHandler<TInputData, TOutputData> : RequestHandlerFilter<TInputData, TOutputData> where TInputData : IInputData where TOutputData : IOutputData
{
}