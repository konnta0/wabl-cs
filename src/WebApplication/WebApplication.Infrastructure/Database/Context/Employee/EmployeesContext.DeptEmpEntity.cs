using Microsoft.EntityFrameworkCore;
using WebApplication.Domain.Entity.Employee;

namespace WebApplication.Infrastructure.Database.Context.Employee;

public partial class EmployeesContext
{
    public DbSet<DeptEmpEntity> DeptEmpEntities => Set<DeptEmpEntity>();
}