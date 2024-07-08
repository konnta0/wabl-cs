using WebApplication.Domain.Repository;
using WebApplication.Domain.Repository.Department;
using WebApplication.Domain.Repository.System;
using WebApplication.Infrastructure.Repository.Department;
using WebApplication.Infrastructure.Repository.System;

namespace WebApplication.Infrastructure.Repository;

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
        { typeof(IFindAllInput), typeof(FindAllInput) },
        { typeof(IGetSystemInfoInput), typeof(GetSystemInfoInput)}
    };
}