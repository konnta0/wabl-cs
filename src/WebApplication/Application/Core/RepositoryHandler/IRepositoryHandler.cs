using Domain.Repository;

namespace Application.Core.RepositoryHandler;

public interface IRepositoryHandler
{
    ValueTask<TOutput> InvokeAsync<TInput, TOutput>(Action<TInput> inputFunc, CancellationToken cancellationToken = new())
        where TInput : IRepositoryInput where TOutput : IRepositoryOutput;
}