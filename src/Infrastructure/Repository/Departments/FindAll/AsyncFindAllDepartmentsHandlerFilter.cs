using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ZLogger;

namespace Infrastructure.Repository.Departments.FindAll;

internal partial class AsyncFindAllDepartmentsHandlerFilter
{
    private readonly ILogger<DepartmentsRepository> _logger;
    private readonly EmployeesContext _employeesContext;

    public AsyncFindAllDepartmentsHandlerFilter(ILogger<DepartmentsRepository> logger, EmployeesContext employeesContext)
    {
        _logger = logger;
        _employeesContext = employeesContext;
    }

    public async ValueTask<FindAllDepartmentsOutputData> HandleAsync(FindAllDepartmentsInputData inputData)
    {
        _logger.ZLogDebug("FindAllDepartmentsOutputData");
        return new FindAllDepartmentsOutputData
        {
            DepartmentsModels = await _employeesContext.DepartmentsModels.AsQueryable().Select(x => x).ToListAsync()
        };
    }
}
