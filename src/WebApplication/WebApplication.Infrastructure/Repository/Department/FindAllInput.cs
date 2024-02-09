using WebApplication.Domain.Repository.Department;

namespace WebApplication.Infrastructure.Repository.Department;

public class FindAllInput : IFindAllInput
{
    public Type CacheOutputType => typeof(FindAllOutput);
}