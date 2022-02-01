using MessagePipe;

namespace UseCase.Core.RequestHandler;

internal interface IInternalUseCaseHandler<in TInputData, out TOutputData>
    where TInputData : struct, IInputData where TOutputData : struct, IOutputData
{
    TOutputData Handle(TInputData inputData);
}