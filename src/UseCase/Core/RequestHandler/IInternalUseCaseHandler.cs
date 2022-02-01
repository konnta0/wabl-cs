using MessagePipe;

namespace UseCase.Core.RequestHandler;

internal abstract class InternalUseCaseHandler<TInputData, TOutputData> : RequestHandlerFilter<TInputData, TOutputData> where TInputData : IInputData where TOutputData : IOutputData
{
}

internal interface IInternalUseCaseHandler<in TInputData, out TOutputData>
    where TInputData : struct, IInputData where TOutputData : struct, IOutputData
{
    TOutputData Handle(TInputData inputData);
}