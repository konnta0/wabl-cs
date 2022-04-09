
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Model.Employees;

public partial class DepartmentsModel
{
    public static partial void OnModelCreating(EntityTypeBuilder<DepartmentsModel> entityTypeBuilder);
}