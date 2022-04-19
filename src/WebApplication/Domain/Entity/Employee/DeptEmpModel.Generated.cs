using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entity.Employee;

public partial class DeptEmpModel : IModel
{ 
    public static partial void OnModelCreating(EntityTypeBuilder<DeptEmpModel> entityTypeBuilder);
}