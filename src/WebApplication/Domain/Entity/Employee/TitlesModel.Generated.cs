using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entity.Employee;

public partial class TitlesModel : IModel
{
    public static partial void OnModelCreating(EntityTypeBuilder<TitlesModel> entityTypeBuilder);
}