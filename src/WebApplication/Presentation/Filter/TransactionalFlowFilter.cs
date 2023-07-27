using Infrastructure.Database.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Presentation.Filter;

public class TransactionalFlowFilter : IAsyncActionFilter
{
    private readonly IDbContextHolder _dbContextHolder;

    public TransactionalFlowFilter(IDbContextHolder dbContextHolder)
    {
        _dbContextHolder = dbContextHolder;
    }
    
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.ActionDescriptor.EndpointMetadata.OfType<HttpPostAttribute>().Any())
        {
            await next();
            return;
        }

        var dbContexts = _dbContextHolder.GetAll();
        // using var scope = new TransactionScope();
        // TODO: exception occurred:
        // System.InvalidOperationException: The configured execution strategy 'MySqlRetryingExecutionStrategy' does not support user-initiated transactions. Use the execution strategy returned by 'DbContext.Database.CreateExecutionStrategy()' to execute all the operations in the transaction as a retriable unit.

        await next();

        await Task.WhenAll(dbContexts.Select(t => t.SaveChangesAsync(false)).Cast<Task>().ToList());
        // scope.Complete();

        foreach (var c in dbContexts)
        {
            c.ChangeTracker.AcceptAllChanges();
        }
    }
}