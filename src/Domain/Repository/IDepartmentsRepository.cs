using Domain.Model;

namespace Domain.Repository;

public interface IDepartmentsRepository
{
    IEnumerable<DepartmentsModel> FindManyByDeptName(string deptName);
}