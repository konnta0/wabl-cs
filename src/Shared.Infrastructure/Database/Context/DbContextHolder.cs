using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using WebApplication.Infrastructure.Database.Context.Employee;

namespace WebApplication.Infrastructure.Database.Context;

public class DbContextHolder : IDbContextHolder, IDisposable
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

    public void Dispose()
    {
        _dbContexts.ForEach(x => x.Dispose());
        _dbContexts.Clear();
    }
}

public interface IDbContextHolder
{
    void Add(DbContext dbContext);
    IImmutableList<DbContext> GetAll();
}