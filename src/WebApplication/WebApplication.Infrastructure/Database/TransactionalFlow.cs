using WebApplication.Application.Core.Database;
using WebApplication.Infrastructure.Database.Context;

namespace WebApplication.Infrastructure.Database;

public class TransactionalFlow : ITransactionalFlow
{
    private readonly IDbContextHolder _dbContextHolder;

    public TransactionalFlow(IDbContextHolder dbContextHolder)
    {
        _dbContextHolder = dbContextHolder;
    }
    
    public async ValueTask SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var dbContexts = _dbContextHolder.GetAll();
        await Task.WhenAll(dbContexts.Select(t => t.SaveChangesAsync(false, cancellationToken)).Cast<Task>().ToList());
    }

    public void AcceptAllChangesAsync()
    {
        var dbContexts = _dbContextHolder.GetAll();

        foreach (var c in dbContexts)
        {
            c.ChangeTracker.AcceptAllChanges();
        }
    }
}