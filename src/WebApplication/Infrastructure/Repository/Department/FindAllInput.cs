using Domain.Repository.Department;

namespace Infrastructure.Repository.Department;

public class FindAllInput : IFindAllInput
{
    public Type CacheOutputType => typeof(FindAllOutput);
}