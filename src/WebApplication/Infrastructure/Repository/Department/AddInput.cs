using Domain.Repository.Department;

namespace Infrastructure.Repository.Department;

public class AddInput : IAddInput
{
    public bool UseTransaction { get; set; } = true;
    public string DepotNo { get; set; } = string.Empty;
    public string DeptName { get; set; } = string.Empty;
}