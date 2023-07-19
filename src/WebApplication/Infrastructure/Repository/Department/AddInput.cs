using Domain.Repository.Department;

namespace Infrastructure.Repository.Department;

public class AddInput : IAddInput
{
    public bool UseTransaction { get; init; } = true;
}