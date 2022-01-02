using Domain.Model;

namespace Domain.Repository;

public interface IDepartmentsRepository
{
    ValueTask<DepartmentsModel?> FindManyByDeptName(string deptName);
}