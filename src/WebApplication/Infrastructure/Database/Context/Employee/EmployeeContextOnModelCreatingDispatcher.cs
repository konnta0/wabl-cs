using Domain.Entity.Employee;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Context.Employee;

public interface IEmployeesContextOnModelCreatingDispatcher : IContextOnModelCreatingDispatcher
{
}

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