using MessagePipe;
using Microsoft.Extensions.Logging;
using ZLogger;

namespace UseCase.Departments;

// ReSharper disable once UnusedType.Global
public partial class AsyncDepartmentsUseCaseHandler : IAsyncRequestHandler<IDepartmentsInputData, IDepartmentsOutputData?>
{
    private readonly ILogger<DepartmentsUseCaseHandler> _logger;

    public AsyncDepartmentsUseCaseHandler(ILogger<DepartmentsUseCaseHandler> logger)
    {
        _logger = logger;
    }

    public ValueTask<IDepartmentsOutputData?> InvokeAsync(IDepartmentsInputData request, CancellationToken cancellationToken = new CancellationToken())
    {
        _logger.ZLogError("NotImplements Filters: {0}, {1}", GetType().ToString(), request);
        return new ValueTask<IDepartmentsOutputData?>();
    }
}
