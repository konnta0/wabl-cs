using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication.Domain.Entity.Employee;

[Table("departments")]
public partial class DepartmentEntity
{
    [Key]
    [Column("dept_no", TypeName = "char(4)")]
    [Required]
    public string DepotNo { get; set; } = string.Empty;

    [Column("dept_name", TypeName = "varchar(40)")]
    [Required]
    public string DeptName { get; set; } = string.Empty;

    public static partial void OnModelCreating(EntityTypeBuilder<DepartmentEntity> entityTypeBuilder)
    {
        entityTypeBuilder.HasIndex(departmentEntity => new { departmentEntity.DeptName }, nameof(DeptName)).IsUnique();
    }
}