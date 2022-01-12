using Domain.Model;

namespace Domain.Repository;

public interface IDepartmentsRepository
{
    ValueTask<IEnumerable<DepartmentsModel>> FindAllAsync();

    ValueTask<DepartmentsModel?> FindManyByDeptNameAsync(string deptName);
}