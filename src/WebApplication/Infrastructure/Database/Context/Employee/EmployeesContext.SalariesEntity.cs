using Domain.Entity.Employee;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Context.Employee;

public partial class EmployeesContext
{
    public DbSet<SalariesEntity> SalariesEntities => Set<SalariesEntity>();
}