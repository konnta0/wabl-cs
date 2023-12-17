using Microsoft.EntityFrameworkCore;

namespace WebApplication.Infrastructure.Database.Context.Employee;

public partial class EmployeesContext : DbContext
{
    public EmployeesContext(DbContextOptions<EmployeesContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new EmployeesContextOnModelCreatingDispatcher().Invoke(modelBuilder);
    }

    public static string GetConnectionString(DatabaseConfig databaseConfig)
    {
        return $"server={databaseConfig.ServerHost};port={databaseConfig.ServerPort};user={databaseConfig.ServerUser};password={databaseConfig.ServerPassword};Database=employees";
    }
}