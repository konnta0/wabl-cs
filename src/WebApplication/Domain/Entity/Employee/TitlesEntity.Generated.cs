using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entity.Employee;

public partial class TitlesEntity : IEntity
{
    public static partial void OnModelCreating(EntityTypeBuilder<TitlesEntity> entityTypeBuilder);
}