using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Model.Employees;

public partial class EmployeesModel : IModel
{
    public static partial void OnModelCreating(EntityTypeBuilder<EmployeesModel> entityTypeBuilder);
}