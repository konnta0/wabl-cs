using MessagePipe;
using UseCase.Departments;
using UseCase.Departments.List;

namespace UseCase.Core.RequestHandler;

internal abstract class AsyncUseCaseHandlerFilter<TFilterInputDataInterface, TFilterOutputDataInterface, TInputData, TOutputData> :
    AsyncRequestHandlerFilter<TFilterInputDataInterface, TFilterOutputDataInterface> where TFilterInputDataInterface : IInputData where TFilterOutputDataInterface : IOutputData,
    IAsyncUseCaseHandlerFilter<TInputData, TOutputData> where TInputData : class, IInputData where TOutputData : class, IOutputData
{
}