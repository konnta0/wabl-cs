using WebApplication.Domain.Repository.Department;

namespace WebApplication.Infrastructure.Repository.Department;

public class AddInput : IAddInput
{
    public bool UseTransaction { get; set; } = true;
    public string DepotNo { get; set; } = string.Empty;
    public string DeptName { get; set; } = string.Empty;
}