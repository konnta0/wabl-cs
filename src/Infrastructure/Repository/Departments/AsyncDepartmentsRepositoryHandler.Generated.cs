using Infrastructure.Core.RequestHandler;
using MessagePipe;
using Microsoft.Extensions.Logging;
using ZLogger;

namespace Infrastructure.Repository.Departments;

public partial class AsyncDepartmentsRepositoryHandler : IAsyncRequestHandler<IDepartmentsInputData, IDepartmentsOutputData?>
{ 
    private readonly ILogger<AsyncDepartmentsRepositoryHandler> _logger;

    public AsyncDepartmentsRepositoryHandler(ILogger<AsyncDepartmentsRepositoryHandler> logger)
    {
        _logger = logger;
    }
    
    public ValueTask<IDepartmentsOutputData?> InvokeAsync(IDepartmentsInputData request, CancellationToken cancellationToken = new CancellationToken())
    {
        _logger.ZLogError("NotImplements Filters: {0}, {1}", GetType().ToString(), request);
#pragma warning disable CS8669
        return new ValueTask<IDepartmentsOutputData?>();
#pragma warning restore CS8669
    }
}