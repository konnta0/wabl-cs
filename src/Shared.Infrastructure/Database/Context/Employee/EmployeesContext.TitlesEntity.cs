using Microsoft.EntityFrameworkCore;
using Shared.Domain.Entity.Employee;

namespace Shared.Infrastructure.Database.Context.Employee;

public partial class EmployeesContext
{
    public DbSet<TitlesEntity> TitlesEntities => Set<TitlesEntity>();
}