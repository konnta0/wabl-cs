namespace Shared.Application.Database;

public interface ITransactionalFlow
{
    ValueTask SaveChangesAsync(CancellationToken cancellationToken = default);
    void AcceptAllChangesAsync();
}