
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Model.Employees;

public partial class DepartmentModel : IModel
{
    public static partial void OnModelCreating(EntityTypeBuilder<DepartmentModel> entityTypeBuilder);
}