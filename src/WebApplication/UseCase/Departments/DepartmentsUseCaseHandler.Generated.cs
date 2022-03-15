using MessagePipe;
using Microsoft.Extensions.Logging;
using ZLogger;

namespace UseCase.Departments;

// ReSharper disable once UnusedType.Global
public partial class DepartmentsUseCaseHandler : IRequestHandler<IDepartmentsInputData, IDepartmentsOutputData>
{
    private readonly ILogger<DepartmentsUseCaseHandler> _logger;

    public DepartmentsUseCaseHandler(ILogger<DepartmentsUseCaseHandler> logger)
    {
        _logger = logger;
    }

    public IDepartmentsOutputData Invoke(IDepartmentsInputData request)
    {
        _logger.ZLogError("NotImplements Filters: {0}, {1}", GetType().ToString(), request);
        return null;
    }
}
