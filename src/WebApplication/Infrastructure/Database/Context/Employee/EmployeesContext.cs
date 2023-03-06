using System.Collections;
using Domain.Entity.Employee;
using MessagePipe;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Context.Employee;

public partial class EmployeesContext : DbContext
{
    private readonly IPublisher<ModelCreatingEvent<EmployeesContext>> _publisher;
    private readonly IEmployeesContextOnModelCreatingBus _onModelCreatingBus;

    public EmployeesContext(DbContextOptions<EmployeesContext> dbContextOptions, IPublisher<ModelCreatingEvent<EmployeesContext>> publisher, IEmployeesContextOnModelCreatingBus onModelCreatingBus) : base(dbContextOptions)
    {
        _publisher = publisher;
        _onModelCreatingBus = onModelCreatingBus;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var employeesContextOnModelCreatingBus in _onModelCreatingBus)
        {
            employeesContextOnModelCreatingBus.Invoke(modelBuilder);
        }
        _publisher.Publish(new ModelCreatingEvent<EmployeesContext> { Builder = modelBuilder });
    }

    public static string GetConnectionString()
    {
        var server = Environment.GetEnvironmentVariable("DB_SERVER_HOST");
        var port = Environment.GetEnvironmentVariable("DB_SERVER_PORT");
        var user = Environment.GetEnvironmentVariable("DB_SERVER_USER");
        var password = Environment.GetEnvironmentVariable("DB_SERVER_PASSWORD");
        return $"server={server};port={port};user={user};password={password};Database=employees";
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
}