using Domain.Repository;

namespace Infrastructure.Repository;

public interface IRepositoryInputTypeResolver
{
    Type? Resolve<TInput>() where TInput : IRepositoryInput;
}