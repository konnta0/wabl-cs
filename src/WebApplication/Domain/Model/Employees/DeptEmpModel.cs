using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Model.Employees;

[Table("dept_emp")]
[Index(nameof(DeptNo), IsUnique = false, Name = "dept_no")]
public partial class DeptEmpModel
{
    [Column("emp_no", TypeName = "int")]
    [Required]
    public int EmpNo { get; set; } = 0;

    [Column("dept_no", TypeName = "varchar(4)")]
    [Required]
    public string DeptNo { get; set; } = "";
    
    [Column("from_date", TypeName = "date")]
    [Required]
    public DateTime FromDate { get; set; }
    
    [Column("to_date", TypeName = "date")]
    [Required]
    public DateTime ToDate { get; set; }
    
    public static partial void OnModelCreating(EntityTypeBuilder<DeptEmpModel> entityTypeBuilder)
    {
    }
}