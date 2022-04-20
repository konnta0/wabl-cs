using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entity.Employee;

public partial class SalariesEntity : IEntity
{
    public static partial void OnModelCreating(EntityTypeBuilder<SalariesEntity> entityTypeBuilder);
}