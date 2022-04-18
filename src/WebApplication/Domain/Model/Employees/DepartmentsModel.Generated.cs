
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Model.Employees;

public partial class DepartmentsModel : IModel
{
    public static partial void OnModelCreating(EntityTypeBuilder<DepartmentsModel> entityTypeBuilder);
}