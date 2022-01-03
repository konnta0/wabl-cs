using Domain.Model;
using Domain.Repository;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repository;

public class DepartmentsRepository : IDepartmentsRepository
{
    private readonly ILogger<DepartmentsRepository> _logger;
    private readonly EmployeesContext _employeesContext;

    public DepartmentsRepository(ILogger<DepartmentsRepository> logger, EmployeesContext employeesContext)
    {
        _logger = logger;
        _employeesContext = employeesContext;
    }

    public async ValueTask<IEnumerable<DepartmentsModel>> FindAll()
    {
        return await _employeesContext.DepartmentsModels.Select(x => x).ToListAsync();
    }

    public async ValueTask<DepartmentsModel?> FindManyByDeptName(string deptName)
    {
        return await _employeesContext.DepartmentsModels.FirstOrDefaultAsync(model => model.DeptName == deptName);
    }
}