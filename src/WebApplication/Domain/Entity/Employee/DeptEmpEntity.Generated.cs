using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entity.Employee;

public partial class DeptEmpEntity : IEntity
{ 
    public static partial void OnModelCreating(EntityTypeBuilder<DeptEmpEntity> entityTypeBuilder);
}