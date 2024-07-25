using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Shared.Application.Database;

namespace WebApplication.Presentation.Filter;

public class TransactionalFlowFilter(ITransactionalFlow transactionalFlow) : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (context.ActionDescriptor.EndpointMetadata.OfType<HttpGetAttribute>().Any())
        {
            await next();
            return;
        }
        // using var scope = new TransactionScope();
        // TODO: exception occurred:
        // System.InvalidOperationException: The configured execution strategy 'MySqlRetryingExecutionStrategy' does not support user-initiated transactions. Use the execution strategy returned by 'DbContext.Database.CreateExecutionStrategy()' to execute all the operations in the transaction as a retriable unit.

        await next();

        await transactionalFlow.SaveChangesAsync();
        // scope.Complete();

        transactionalFlow.AcceptAllChangesAsync();
    }
}