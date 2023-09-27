namespace Application.Core.Database;

public interface ITransactionalFlow
{
    ValueTask SaveChangesAsync(CancellationToken cancellationToken = default);
    void AcceptAllChangesAsync();
}