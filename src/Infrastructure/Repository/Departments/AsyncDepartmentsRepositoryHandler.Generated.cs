using Infrastructure.Core.RequestHandler;
using MessagePipe;
using Microsoft.Extensions.Logging;
using ZLogger;

namespace Infrastructure.Repository.Departments;

#nullable enable
public partial class AsyncDepartmentsRepositoryHandler : IAsyncRepositoryHandler<IDepartmentsInputData, IDepartmentsOutputData?>
{ 
    private readonly ILogger<AsyncDepartmentsRepositoryHandler> _logger;

    public AsyncDepartmentsRepositoryHandler(ILogger<AsyncDepartmentsRepositoryHandler> logger)
    {
        _logger = logger;
    }
    
    public ValueTask<IDepartmentsOutputData?> InvokeAsync(IDepartmentsInputData request, CancellationToken cancellationToken = new CancellationToken())
    {
        _logger.ZLogError("NotImplements Filters: {0}, {1}", GetType().ToString(), request);
        return new ValueTask<IDepartmentsOutputData?>();
    }

    public async ValueTask<TResponse?> InvokeAsync<TResponse>(IDepartmentsInputData request, CancellationToken cancellationToken = default)
    {
        var response = await InvokeAsync(request, cancellationToken);
        if (response is null)
        {
            return default;
        }

        return (TResponse)response;
    }
}