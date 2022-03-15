using MessagePipe;
using Microsoft.Extensions.Logging;
using UseCase.Core.RequestHandler;
using ZLogger;

namespace UseCase.Departments;

// ReSharper disable once UnusedType.Global
public partial class AsyncDepartmentsUseCaseHandler : IAsyncUseCaseHandler<IDepartmentsInputData, IDepartmentsOutputData>
{
    private readonly ILogger<AsyncDepartmentsUseCaseHandler> _logger;

    public AsyncDepartmentsUseCaseHandler(ILogger<AsyncDepartmentsUseCaseHandler> logger)
    {
        _logger = logger;
    }

    public ValueTask<IDepartmentsOutputData> InvokeAsync(IDepartmentsInputData request, CancellationToken cancellationToken = new CancellationToken())
    {
        _logger.ZLogError("NotImplements Filters: {0}, {1}", GetType().ToString(), request);
        return new ValueTask<IDepartmentsOutputData>();
    }
}
