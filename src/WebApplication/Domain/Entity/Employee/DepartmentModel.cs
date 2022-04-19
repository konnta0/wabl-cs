using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entity.Employee;

[Table("departments")]
public partial class DepartmentModel
{
    [Key]
    [Column("dept_no", TypeName = "char(4)")]
    [Required]
    public string DepotNo { get; set; } = string.Empty;

    [Column("dept_name", TypeName = "varchar(40)")]
    [Required]
    public string DeptName { get; set; } = string.Empty;

    public static partial void OnModelCreating(EntityTypeBuilder<DepartmentModel> entityTypeBuilder)
    {
        entityTypeBuilder.HasIndex(departmentsModel => new { departmentsModel.DeptName }, nameof(DeptName)).IsUnique();
    }
}