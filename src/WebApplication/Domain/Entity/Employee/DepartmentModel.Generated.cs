using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entity.Employee;

public partial class DepartmentModel : IModel
{
    public static partial void OnModelCreating(EntityTypeBuilder<DepartmentModel> entityTypeBuilder);
}