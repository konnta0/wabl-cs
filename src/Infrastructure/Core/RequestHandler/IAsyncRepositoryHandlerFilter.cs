namespace Infrastructure.Core.RequestHandler;

internal interface IAsyncRepositoryHandlerFilter<in TInputData, TOutputData>
    where TInputData : class, IInputData where TOutputData : class, IOutputData
{
    ValueTask<TOutputData> HandleAsync(TInputData inputData);
}