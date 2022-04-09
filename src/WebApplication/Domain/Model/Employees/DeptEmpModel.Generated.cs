using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Model.Employees;

public partial class DeptEmpModel
{ 
    public static partial void OnModelCreating(EntityTypeBuilder<DeptEmpModel> entityTypeBuilder);
}