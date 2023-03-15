using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entity.Employee;

public partial class TitlesEntity : IEntity, IHasSeed
{
    public static partial void OnModelCreating(EntityTypeBuilder<TitlesEntity> entityTypeBuilder);
}