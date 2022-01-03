using Domain.Model;

namespace Domain.Repository;

public interface IDepartmentsRepository
{
    ValueTask<IEnumerable<DepartmentsModel>> FindAll();

    ValueTask<DepartmentsModel?> FindManyByDeptName(string deptName);
}