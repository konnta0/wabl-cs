using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entity.Employee;

public partial class EmployeesEntity : IEntity
{
    public static partial void OnModelCreating(EntityTypeBuilder<EmployeesEntity> entityTypeBuilder);
}