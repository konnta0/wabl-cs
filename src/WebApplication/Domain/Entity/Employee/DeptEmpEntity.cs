using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entity.Employee;

[Table("dept_emp")]
public partial class DeptEmpEntity
{
    [Column("emp_no", TypeName = "int")]
    [Required]
    public int EmpNo { get; set; } = 0;

    [Column("dept_no", TypeName = "varchar(4)")]
    [Required]
    public string DeptNo { get; set; } = string.Empty;
    
    [Column("from_date", TypeName = "date")]
    [Required]
    public DateTime FromDate { get; set; }
    
    [Column("to_date", TypeName = "date")]
    [Required]
    public DateTime ToDate { get; set; }
    
    public static partial void OnModelCreating(EntityTypeBuilder<DeptEmpEntity> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(deptEmpEntity => new { deptEmpEntity.EmpNo, deptEmpEntity.DeptNo });
        entityTypeBuilder.HasIndex(deptEmpEntity => new { deptEmpEntity.DeptNo }, nameof(DeptNo)).IsUnique(false);
        entityTypeBuilder.HasMany<EmployeesEntity>().WithOne();
        entityTypeBuilder.HasMany<DepartmentEntity>().WithOne();
    }
}