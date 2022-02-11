namespace Infrastructure.Core.RequestHandler;

internal interface IAsyncRepositoryHandlerFilter<in TInputData, TOutputData>
    where TInputData : class, IRepositoryInputData where TOutputData : class, IRepositoryOutputData
{
    ValueTask<TOutputData> HandleAsync(TInputData inputData);
}