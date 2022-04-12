using Domain.Model.Employees;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Context;

public partial class EmployeesContext
{
    public DbSet<DeptEmpModel> DeptEmpModels => Set<DeptEmpModel>();
}