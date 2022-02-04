namespace Infrastructure.Core.RequestHandler;

internal interface IAsyncInternalRepositoryHandler<in TInputData, TOutputData>
    where TInputData : class, IInputData where TOutputData : class, IOutputData
{
    ValueTask<TOutputData> HandleAsync(TInputData inputData);
}