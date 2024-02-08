namespace WebApplication.Domain.Repository;

public interface ITransactionalInput : IRepositoryInput
{
    bool UseTransaction => true;
}