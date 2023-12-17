using Domain.Repository;

namespace WebApplication.Infrastructure.Repository;

public interface IRepositoryInputTypeResolver
{
    Type? Resolve<TInput>() where TInput : IRepositoryInput;
}