using MessagePipe;

namespace Infrastructure.Core.RequestHandler;

public interface IAsyncRepositoryHandler<in TInput, TOut> : IAsyncRequestHandler<TInput, TOut> where TInput : IInputData where TOut : IOutputData
{
}