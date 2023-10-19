
using Application.Departments.Dto;

namespace Application.UseCase.Departments.Dto;

public sealed class AddDepartmentsUseCaseInput : IDepartmentsUseCaseInput
{
    public string DepotNo { get; init; } = "";
    public string DeptName { get; init; } = "";
}