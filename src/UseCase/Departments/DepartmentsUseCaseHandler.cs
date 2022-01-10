using MessagePipe;
using Microsoft.Extensions.Logging;
using UseCase.Departments.Find;
using ZLogger;

namespace UseCase.Departments;

[RequestHandlerFilter(typeof(FindDepartmentsHandler))]
[RequestHandlerFilter(typeof(FindManyDepartmentsHandler))]
// ReSharper disable once UnusedType.Global
public class DepartmentsUseCaseHandler : IRequestHandler<IDepartmentsInputData, IDepartmentsOutputData?>
{
    private readonly ILogger<DepartmentsUseCaseHandler> _logger;

    public DepartmentsUseCaseHandler(ILogger<DepartmentsUseCaseHandler> logger)
    {
        _logger = logger;
    }

    public IDepartmentsOutputData? Invoke(IDepartmentsInputData request)
    {
        _logger.ZLogInformation("[UseCaseHandler]");
        return null;
    }
}

internal class FindDepartmentsHandler : RequestHandlerFilter<IDepartmentsInputData, IDepartmentsOutputData>
{
    private readonly ILogger<FindDepartmentsHandler> _logger;

    public FindDepartmentsHandler(ILogger<FindDepartmentsHandler> logger)
    {
        _logger = logger;
    }

    public override IDepartmentsOutputData Invoke(IDepartmentsInputData request, Func<IDepartmentsInputData, IDepartmentsOutputData> next)
    {
        _logger.ZLogInformation("[FindDepartmentsHandler] : Called");
        if (request is not FindDepartmentsInputData)
        {
            return next(request);
        }

        return new FindDepartmentsOutputData {TestParam = 10};
    }
}

internal class FindManyDepartmentsHandler : RequestHandlerFilter<IDepartmentsInputData, IDepartmentsOutputData>
{
    private readonly ILogger<FindManyDepartmentsHandler> _logger;

    public FindManyDepartmentsHandler(ILogger<FindManyDepartmentsHandler> logger)
    {
        _logger = logger;
    }

    public override IDepartmentsOutputData Invoke(IDepartmentsInputData request, Func<IDepartmentsInputData, IDepartmentsOutputData> next)
    {
        _logger.ZLogInformation("[FindManyDepartmentsHandler] : Called");
        if (request is not FindManyDepartmentsInputData)
        {
            return next(request);
        }

        return new FindManyDepartmentsOutputData {Param = 900000};
    }
}
