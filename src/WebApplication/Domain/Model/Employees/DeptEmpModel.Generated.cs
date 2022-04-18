using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Model.Employees;

public partial class DeptEmpModel : IModel
{ 
    public static partial void OnModelCreating(EntityTypeBuilder<DeptEmpModel> entityTypeBuilder);
}