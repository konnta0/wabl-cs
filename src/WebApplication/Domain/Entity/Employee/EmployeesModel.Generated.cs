using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entity.Employee;

public partial class EmployeesModel : IModel
{
    public static partial void OnModelCreating(EntityTypeBuilder<EmployeesModel> entityTypeBuilder);
}