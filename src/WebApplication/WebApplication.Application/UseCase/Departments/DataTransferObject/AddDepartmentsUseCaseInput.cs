namespace WebApplication.Application.UseCase.Departments.DataTransferObject;

public sealed class AddDepartmentsUseCaseInput : IDepartmentsUseCaseInput
{
    public string DepotNo { get; init; } = "";
    public string DeptName { get; init; } = "";
}