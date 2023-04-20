using System.Text.Json;
using Domain.Repository.Department.FindAll;
using Infrastructure.Cache;
using Infrastructure.Database.Context.Employee;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repository.Department.FindAll;

internal partial class AsyncFindAllDepartmentHandlerFilter : IAsyncFindAllDepartmentHandlerFilter
{
    private readonly ILogger<AsyncFindAllDepartmentHandlerFilter> _logger;
    private readonly EmployeesContext _employeesContext;
    public IVolatileCacheClient CacheClient { get; set; }

    public AsyncFindAllDepartmentHandlerFilter(ILogger<AsyncFindAllDepartmentHandlerFilter> logger, IVolatileCacheClient cacheClient, EmployeesContext employeesContext)
    {
        _logger = logger;
        CacheClient = cacheClient;
        _employeesContext = employeesContext;
    }

    public async ValueTask<IFindAllDepartmentRepositoryOutputData> HandleAsync(IFindAllDepartmentRepositoryInputData repositoryInputData)
    {
        return new FindAllDepartmentRepositoryOutputData
        {
            DepartmentsEntities = await _employeesContext.DepartmentsEntities.AsQueryable().Select(x => x).ToListAsync()
        };
    }

    public ValueTask<IFindAllDepartmentRepositoryOutputData> HandleAsync(string cacheString)
    {
        var outputData = JsonSerializer.Deserialize<FindAllDepartmentRepositoryOutputData>(cacheString);
        if (outputData is null)
        {
            return new ValueTask<IFindAllDepartmentRepositoryOutputData>(new FindAllDepartmentRepositoryOutputData());
        }
        return ValueTask.FromResult<IFindAllDepartmentRepositoryOutputData>(outputData);
    }
}
