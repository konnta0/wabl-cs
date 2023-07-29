using Domain.Repository.Department;

namespace Infrastructure.Repository.Department;

public class AddInput : IAddInput
{
    public bool UseTransaction { get; init; } = true;
    public string DepotNo { get; init; } = string.Empty;
    public string DeptName { get; init; } = string.Empty;
}