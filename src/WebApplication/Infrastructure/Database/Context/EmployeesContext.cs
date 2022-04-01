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
        modelBuilder.Entity<SalariesModel>()
            .HasKey(salariesModel => new { salariesModel.EmpNo, salariesModel.FromDate });
    }

    public DbSet<DepartmentsModel> DepartmentsModels => Set<DepartmentsModel>();
    public DbSet<SalariesModel> SalariesModels => Set<SalariesModel>();
    public DbSet<EmployeesModel> EmployeesModels => Set<EmployeesModel>();

    public static string GetConnectionString()
    {
        var server = Environment.GetEnvironmentVariable("MYSQL_SERVER_HOST");
        var port = Environment.GetEnvironmentVariable("MYSQL_SERVER_PORT");
        var user = Environment.GetEnvironmentVariable("MYSQL_USER");
        var password = Environment.GetEnvironmentVariable("MYSQL_PASSWORD");
        return $"server={server};port={port};user={user};password={password};Database=employees";
    }
}