using Microsoft.EntityFrameworkCore;
using Shared.Domain.Entity.Employee;
using WebApplication.Infrastructure.Database.Context;

namespace Shared.Infrastructure.Database.Context.Employee;

public interface IEmployeesContextOnModelCreatingDispatcher : IContextOnModelCreatingDispatcher;

public class EmployeesContextOnModelCreatingDispatcher : IEmployeesContextOnModelCreatingDispatcher
{
    public void Invoke(ModelBuilder modelBuilder)
    {
        DepartmentEntity.OnModelCreating(modelBuilder.Entity<DepartmentEntity>());
        DeptEmpEntity.OnModelCreating(modelBuilder.Entity<DeptEmpEntity>());
        EmployeesEntity.OnModelCreating(modelBuilder.Entity<EmployeesEntity>());
        SalariesEntity.OnModelCreating(modelBuilder.Entity<SalariesEntity>());
        TitlesEntity.OnModelCreating(modelBuilder.Entity<TitlesEntity>());    
    }
}