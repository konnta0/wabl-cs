using Domain.Entity.Employee;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Context;

public partial class EmployeesContext
{
    public DbSet<DepartmentModel> DepartmentsModels => Set<DepartmentModel>();
}