using Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repository.Departments.FindAll;

internal partial class AsyncFindAllDepartmentsHandlerFilter
{
    private readonly ILogger<AsyncFindAllDepartmentsHandlerFilter> _logger;
    private readonly EmployeesContext _employeesContext;

    public AsyncFindAllDepartmentsHandlerFilter(ILogger<AsyncFindAllDepartmentsHandlerFilter> logger, EmployeesContext employeesContext)
    {
        _logger = logger;
        _employeesContext = employeesContext;
    }

    public async ValueTask<FindAllDepartmentsRepositoryOutputData> HandleAsync(FindAllDepartmentsRepositoryInputData repositoryInputData)
    {
        return new FindAllDepartmentsRepositoryOutputData
        {
            DepartmentsModels = await _employeesContext.DepartmentsModels.AsQueryable().Select(x => x).ToListAsync()
        };
    }
}
