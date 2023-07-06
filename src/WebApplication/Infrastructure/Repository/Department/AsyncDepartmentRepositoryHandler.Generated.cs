using Domain.Repository.Department;
using Infrastructure.Core.RequestHandler;
using Microsoft.Extensions.Logging;
using ZLogger;

namespace Infrastructure.Repository.Department;

#nullable enable
public partial class AsyncDepartmentRepositoryHandler : IAsyncRepositoryHandler<IDepartmentRepositoryInputData, IDepartmentRepositoryOutputData?>
{ 
    private readonly ILogger<AsyncDepartmentRepositoryHandler> _logger;

    public AsyncDepartmentRepositoryHandler(ILogger<AsyncDepartmentRepositoryHandler> logger)
    {
        _logger = logger;
    }
    
    public ValueTask<IDepartmentRepositoryOutputData?> InvokeAsync(IDepartmentRepositoryInputData request, CancellationToken cancellationToken = new CancellationToken())
    {
        _logger.ZLogError("NotImplements Filters: {0}, {1}", GetType().ToString(), request);
        return new ValueTask<IDepartmentRepositoryOutputData?>();
    }

    public async ValueTask<TResponse?> InvokeAsync<TResponse>(IDepartmentRepositoryInputData request, CancellationToken cancellationToken = default)
    {
        var response = await InvokeAsync(request, cancellationToken);
        if (response is null)
        {
            return default;
        }

        return (TResponse)response;
    }
}