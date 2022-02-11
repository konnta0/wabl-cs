using Domain.Repository;
using MessagePipe;

namespace Infrastructure.Core.RequestHandler;

public interface IAsyncRepositoryHandler<in TInput, TOut> : IAsyncRequestHandler<TInput, TOut> where TInput : IRepositoryInputData where TOut : IRepositoryOutputData?
{ 
    ValueTask<TResponse?> InvokeAsync<TResponse>(TInput request, CancellationToken cancellationToken = default);
}