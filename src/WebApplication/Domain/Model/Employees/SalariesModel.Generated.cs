using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Model.Employees;

public partial class SalariesModel : IModel
{
    public static partial void OnModelCreating(EntityTypeBuilder<SalariesModel> entityTypeBuilder);
}