using Shared.Application.Database;
using Shared.Infrastructure.Database.Context;

namespace Shared.Infrastructure.Database;

public class TransactionalFlow(IDbContextHolder dbContextHolder) : ITransactionalFlow
{
    public async ValueTask SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var dbContexts = dbContextHolder.GetAll();
        await Task.WhenAll(dbContexts.Select(t => t.SaveChangesAsync(false, cancellationToken)).Cast<Task>().ToList());
    }

    public void AcceptAllChangesAsync()
    {
        var dbContexts = dbContextHolder.GetAll();

        foreach (var c in dbContexts)
        {
            c.ChangeTracker.AcceptAllChanges();
        }
    }
}