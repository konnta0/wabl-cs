using System.Collections;
using Domain.Model.Employees;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Context;

public partial class EmployeesContext : DbContext
{
    private readonly IEmployeesContextOnModelCreatingBus _onModelCreatingBus;

    public EmployeesContext(DbContextOptions<EmployeesContext> dbContextOptions,
        IEmployeesContextOnModelCreatingBus onModelCreatingBus) : base(dbContextOptions)
    {
        _onModelCreatingBus = onModelCreatingBus;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var employeesContextOnModelCreatingBus in _onModelCreatingBus)
        {
            employeesContextOnModelCreatingBus.Invoke(modelBuilder);
        }
    }

    public static string GetConnectionString()
    {
        var server = Environment.GetEnvironmentVariable("MYSQL_SERVER_HOST");
        var port = Environment.GetEnvironmentVariable("MYSQL_SERVER_PORT");
        var user = Environment.GetEnvironmentVariable("MYSQL_USER");
        var password = Environment.GetEnvironmentVariable("MYSQL_PASSWORD");
        return $"server={server};port={port};user={user};password={password};Database=employees";
    }
}

public readonly struct EmployeesContextOnModelCreatingBus : IEmployeesContextOnModelCreatingBus
{
    public IEnumerator<Action<ModelBuilder>> GetEnumerator()
    {
        yield return builder => DepartmentModel.OnModelCreating(builder.Entity<DepartmentModel>());
        yield return builder => DeptEmpModel.OnModelCreating(builder.Entity<DeptEmpModel>());
        yield return builder => EmployeesModel.OnModelCreating(builder.Entity<EmployeesModel>());
        yield return builder => SalariesModel.OnModelCreating(builder.Entity<SalariesModel>());
    }

    public int Count { get; }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public interface IEmployeesContextOnModelCreatingBus : IContextOnModelCreatingBus
{
}

public interface IContextOnModelCreatingBus : IReadOnlyCollection<Action<ModelBuilder>>
{
}