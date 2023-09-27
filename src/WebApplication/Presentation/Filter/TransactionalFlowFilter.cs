using Application.Core.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Presentation.Filter;

public class TransactionalFlowFilter : IAsyncActionFilter
{
    private readonly ITransactionalFlow _transactionalFlow;

    public TransactionalFlowFilter(ITransactionalFlow transactionalFlow)
    {

        _transactionalFlow = transactionalFlow;
    }
    
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.ActionDescriptor.EndpointMetadata.OfType<HttpPostAttribute>().Any())
        {
            await next();
            return;
        }
        // using var scope = new TransactionScope();
        // TODO: exception occurred:
        // System.InvalidOperationException: The configured execution strategy 'MySqlRetryingExecutionStrategy' does not support user-initiated transactions. Use the execution strategy returned by 'DbContext.Database.CreateExecutionStrategy()' to execute all the operations in the transaction as a retriable unit.

        await next();

        await _transactionalFlow.SaveChangesAsync();
        // scope.Complete();

        _transactionalFlow.AcceptAllChangesAsync();
    }
}