using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Model.Employees;

[Table("dept_emp")]
public partial class DeptEmpModel
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
    
    public static partial void OnModelCreating(EntityTypeBuilder<DeptEmpModel> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(deptEmpModel => new { deptEmpModel.EmpNo, deptEmpModel.DeptNo });
        entityTypeBuilder.HasIndex(deptEmpModel => new { deptEmpModel.DeptNo }, nameof(DeptNo)).IsUnique(false);
        entityTypeBuilder.HasMany<EmployeesModel>().WithOne();
        entityTypeBuilder.HasMany<DepartmentModel>().WithOne();
    }
}