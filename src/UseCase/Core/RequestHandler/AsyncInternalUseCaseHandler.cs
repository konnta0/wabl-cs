using MessagePipe;

namespace UseCase.Core.RequestHandler;

internal abstract class AsyncInternalUseCaseHandler<TInputData, TOutputData> : AsyncRequestHandlerFilter<TInputData, TOutputData> where TInputData : IInputData where TOutputData : IOutputData
{
}