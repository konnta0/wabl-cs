using Domain.Entity.Employee;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Infrastructure.Database.Context.Employee;

public partial class EmployeesContext
{
    public DbSet<DeptEmpEntity> DeptEmpEntities => Set<DeptEmpEntity>();
}