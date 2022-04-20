using System.Collections;
using Domain.Entity.Employee;
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
        yield return builder => DepartmentEntity.OnModelCreating(builder.Entity<DepartmentEntity>());
        yield return builder => DeptEmpEntity.OnModelCreating(builder.Entity<DeptEmpEntity>());
        yield return builder => EmployeesEntity.OnModelCreating(builder.Entity<EmployeesEntity>());
        yield return builder => SalariesEntity.OnModelCreating(builder.Entity<SalariesEntity>());
        yield return builder => TitlesEntity.OnModelCreating(builder.Entity<TitlesEntity>());
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