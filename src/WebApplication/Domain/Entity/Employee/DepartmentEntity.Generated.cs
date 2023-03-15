using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entity.Employee;

public partial class DepartmentEntity : IEntity
{
    public static partial void OnModelCreating(EntityTypeBuilder<DepartmentEntity> entityTypeBuilder);
}