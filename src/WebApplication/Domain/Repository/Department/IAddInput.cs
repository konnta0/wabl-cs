namespace Domain.Repository.Department;

public interface IAddInput : ITransactionalInput, IDepartmentRepositoryInput
{
    public string DepotNo { get; init; }
    public string DeptName { get; init; }
}