using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entity.Employee;

public partial class SalariesModel : IModel
{
    public static partial void OnModelCreating(EntityTypeBuilder<SalariesModel> entityTypeBuilder);
}