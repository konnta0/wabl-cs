using Domain.Repository;
using MessagePipe;

namespace Infrastructure.Core.RequestHandler;

internal abstract class AsyncRepositoryHandlerBase<TInput, TOutput> : IAsyncRequestHandler<TInput, TOutput?> where TInput : IRepositoryInput, IRepositoryOutput
{
    public ValueTask<TOutput?> InvokeAsync(TInput request, CancellationToken cancellationToken = new CancellationToken())
    {
        throw new NotImplementedException();
    }
}