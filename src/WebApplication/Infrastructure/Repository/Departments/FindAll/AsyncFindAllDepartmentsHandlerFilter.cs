using Domain.Repository.Departments.FindAll;
using Infrastructure.Cache;
using Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repository.Departments.FindAll;

internal partial class AsyncFindAllDepartmentsHandlerFilter : IAsyncFindAllDepartmentsHandlerFilter
{
    private readonly ILogger<AsyncFindAllDepartmentsHandlerFilter> _logger;
    private readonly EmployeesContext _employeesContext;
    public ICacheClient CacheClient { get; set; }

    public AsyncFindAllDepartmentsHandlerFilter(ILogger<AsyncFindAllDepartmentsHandlerFilter> logger, ICacheClient cacheClient, EmployeesContext employeesContext)
    {
        _logger = logger;
        CacheClient = cacheClient;
        _employeesContext = employeesContext;
    }

    public async ValueTask<IFindAllDepartmentsRepositoryOutputData> HandleAsync(IFindAllDepartmentsRepositoryInputData repositoryInputData)
    {
        return new FindAllDepartmentsRepositoryOutputData
        {
            DepartmentsModels = await _employeesContext.DepartmentsModels.AsQueryable().Select(x => x).ToListAsync()
        };
    }

    public void Dispose()
    {
        CacheClient.Dispose();
    }
}
