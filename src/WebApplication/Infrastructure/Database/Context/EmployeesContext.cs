using Domain.Model;
using Domain.Model.Employees;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Context;

public class EmployeesContext : DbContext
{
    public EmployeesContext(DbContextOptions<EmployeesContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }

    public DbSet<DepartmentsModel>? DepartmentsModels { get; set; }

    public static string GetConnectionString()
    {
        var server = Environment.GetEnvironmentVariable("MYSQL_SERVER_HOST");
        var port = Environment.GetEnvironmentVariable("MYSQL_SERVER_PORT");
        var user = Environment.GetEnvironmentVariable("MYSQL_USER");
        var password = Environment.GetEnvironmentVariable("MYSQL_PASSWORD");
        return $"server={server};port={port};user={user};password={password};Database=employees";
    }
}