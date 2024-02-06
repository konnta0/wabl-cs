using MessagePack;

namespace WebApplication.Domain.RestApi.Departments.Object;

[MessagePackObject]
public class Department
{
    [Key(0)]
    public string DepotNo { get; init; } = "";

    [Key(1)]
    public string DeptName { get; init; } = "";
}