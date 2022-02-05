namespace UseCase.Core.RequestHandler;

internal interface IAsyncUseCaseHandlerFilter<in TInputData, TOutputData>
    where TInputData : class, IInputData where TOutputData : class, IOutputData
{
    ValueTask<TOutputData> HandleAsync(TInputData inputData);
}