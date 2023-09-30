
namespace Application.Departments.Dto;

public class AddDepartmentsUseCaseInput : IDepartmentsUseCaseInput
{
    public string DepotNo { get; init; } = "";
    public string DeptName { get; init; } = "";
}