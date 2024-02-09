using Microsoft.EntityFrameworkCore;
using WebApplication.Domain.Entity.Employee;

namespace WebApplication.Infrastructure.Database.Context.Employee;

public partial class EmployeesContext
{
    public DbSet<DepartmentEntity> DepartmentsEntities => Set<DepartmentEntity>();
}