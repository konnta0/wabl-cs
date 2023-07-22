using Domain.Repository;

namespace Infrastructure.Core.RequestHandler;

public interface IRepositoryHandler
{
    ValueTask<TOutput> InvokeAsync<TInput, TOutput>(TInput input, CancellationToken cancellationToken = new())
        where TInput : IRepositoryInput where TOutput : IRepositoryOutput;
}