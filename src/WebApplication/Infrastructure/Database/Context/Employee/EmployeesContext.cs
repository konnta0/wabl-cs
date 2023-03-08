using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Context.Employee;

public partial class EmployeesContext : DbContext
{
    public EmployeesContext(DbContextOptions<EmployeesContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new EmployeesContextOnModelCreatingDispatcher().Invoke(modelBuilder);
    }

    public static string GetConnectionString()
    {
        var server = Environment.GetEnvironmentVariable("DB_SERVER_HOST");
        var port = Environment.GetEnvironmentVariable("DB_SERVER_PORT");
        var user = Environment.GetEnvironmentVariable("DB_SERVER_USER");
        var password = Environment.GetEnvironmentVariable("DB_SERVER_PASSWORD");
        return $"server={server};port={port};user={user};password={password};Database=employees";
    }
}