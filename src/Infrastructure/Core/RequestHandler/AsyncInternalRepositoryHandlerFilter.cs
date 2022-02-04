using MessagePipe;

namespace Infrastructure.Core.RequestHandler;

internal abstract class AsyncInternalRepositoryHandlerFilter<TInputData, TOutputData> : AsyncRequestHandlerFilter<TInputData, TOutputData> where TInputData : IInputData where TOutputData : IOutputData
{
}