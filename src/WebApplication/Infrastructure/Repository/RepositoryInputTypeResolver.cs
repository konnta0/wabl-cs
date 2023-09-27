using Domain.Repository;
using Domain.Repository.Department;
using Infrastructure.Repository.Department;

namespace Infrastructure.Repository;

internal class RepositoryInputTypeResolver : IRepositoryInputTypeResolver
{
    public Type? Resolve<TInput>() where TInput : IRepositoryInput
    {
        var result = TypeMap.TryGetValue(typeof(TInput), out var type);
        return result ? type : null;
    }

    private static readonly Dictionary<Type, Type> TypeMap = new()
    {
        { typeof(IAddInput), typeof(AddInput) },
        { typeof(IFindAllInput), typeof(FindAllInput) }
    };
}