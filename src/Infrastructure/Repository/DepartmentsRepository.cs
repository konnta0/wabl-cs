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

    public async ValueTask<DepartmentsModel?> FindManyByDeptName(string deptName)
    {
        return await _employeesContext.DepartmentsModels.FirstOrDefaultAsync(model => model != null && model.DeptName == deptName);
    }
}