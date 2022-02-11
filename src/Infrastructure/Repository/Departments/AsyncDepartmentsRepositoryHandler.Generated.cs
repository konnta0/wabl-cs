using Infrastructure.Core.RequestHandler;
using MessagePipe;
using Microsoft.Extensions.Logging;
using ZLogger;

namespace Infrastructure.Repository.Departments;

#nullable enable
public partial class AsyncDepartmentsRepositoryHandler : IAsyncRepositoryHandler<IDepartmentsRepositoryInputData, IDepartmentsRepositoryOutputData?>
{ 
    private readonly ILogger<AsyncDepartmentsRepositoryHandler> _logger;

    public AsyncDepartmentsRepositoryHandler(ILogger<AsyncDepartmentsRepositoryHandler> logger)
    {
        _logger = logger;
    }
    
    public ValueTask<IDepartmentsRepositoryOutputData?> InvokeAsync(IDepartmentsRepositoryInputData request, CancellationToken cancellationToken = new CancellationToken())
    {
        _logger.ZLogError("NotImplements Filters: {0}, {1}", GetType().ToString(), request);
        return new ValueTask<IDepartmentsRepositoryOutputData?>();
    }

    public async ValueTask<TResponse?> InvokeAsync<TResponse>(IDepartmentsRepositoryInputData request, CancellationToken cancellationToken = default)
    {
        var response = await InvokeAsync(request, cancellationToken);
        if (response is null)
        {
            return default;
        }

        return (TResponse)response;
    }
}