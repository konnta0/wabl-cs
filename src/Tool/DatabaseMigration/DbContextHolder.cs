using System.Collections.Immutable;
using Infrastructure.Database.Context.Employee;
using Microsoft.EntityFrameworkCore;

namespace DatabaseMigration;

public class DbContextHolder : IDbContextHolder
{
    private readonly List<DbContext> _dbContexts = new();

    public DbContextHolder(EmployeesContext employeesContext)
    {
        Add(employeesContext);
    }

    public void Add(DbContext dbContext)
    {
        _dbContexts.Add(dbContext);
    }

    public IImmutableList<DbContext> GetAll() => _dbContexts.ToImmutableList();
}

public interface IDbContextHolder
{
    void Add(DbContext dbContext);
    IImmutableList<DbContext> GetAll();
}