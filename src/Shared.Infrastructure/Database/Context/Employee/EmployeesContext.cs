using Microsoft.EntityFrameworkCore;

namespace Shared.Infrastructure.Database.Context.Employee;

public partial class EmployeesContext(DbContextOptions<EmployeesContext> dbContextOptions) : DbContext(dbContextOptions)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new EmployeesContextOnModelCreatingDispatcher().Invoke(modelBuilder);
    }

    public static string GetConnectionString(DatabaseConfig databaseConfig)
    {
        return $"server={databaseConfig.ServerHost};port={databaseConfig.ServerPort};user={databaseConfig.ServerUser};password={databaseConfig.ServerPassword};Database=app_db";
    }
}