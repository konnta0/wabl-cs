using MessagePipe;

namespace UseCase.Core;

internal abstract class AsyncInternalUseCaseHandler<TInputData, TOutputData> : AsyncRequestHandlerFilter<TInputData, TOutputData> where TInputData : IInputData where TOutputData : IOutputData
{
}

internal interface IAsyncInternalUseCaseHandler<in TInputData, TOutputData>
    where TInputData : class, IInputData where TOutputData : class, IOutputData
{
    ValueTask<TOutputData> HandleAsync(TInputData inputData);
}