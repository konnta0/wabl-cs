using Domain.Model;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;

namespace Infrastructure.Context;

public class EmployeesContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DepartmentsModel>(entity =>
        {
            entity.ForMySQLHasCharset("utf8mb4");
            entity.ForMySQLHasCollation("utf8mb4_bin");
            entity.Property(p => p.DepotNo).ForMySQLHasCollation("utf8mb4_bin");
            entity.Property(p => p.DeptName).ForMySQLHasCollation("utf8mb4_bin");
        });
    }
    
    public DbSet<DepartmentsModel> DepartmentsModels { get; set; }

    public static string GetConnectionString()
    {
        var server = Environment.GetEnvironmentVariable("MYSQL_SERVER_HOST");
        var port = Environment.GetEnvironmentVariable("MYSQL_SERVER_PORT");
        var user = Environment.GetEnvironmentVariable("MYSQL_USER");
        var password = Environment.GetEnvironmentVariable("MYSQL_PASSWORD");
        return $"server={server};port={port};user={user};password={password};Database=employees";
    }
}