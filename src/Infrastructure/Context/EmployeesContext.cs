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
}