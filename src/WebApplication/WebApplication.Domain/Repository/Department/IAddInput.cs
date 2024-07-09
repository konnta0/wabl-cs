using WebApplication.Domain.Repository.Department.Core;

namespace WebApplication.Domain.Repository.Department;

public interface IAddInput : ITransactionalInput, IDepartmentRepositoryInput
{
    public string DepotNo { get; set; }
    public string DeptName { get; set; }
}