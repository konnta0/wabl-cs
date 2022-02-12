using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Model;

[Table("departments")]
[Index(nameof(DeptName), IsUnique = true, Name = "dept_name")]
public class DepartmentsModel
{
    [Key]
    [Column("dept_no", TypeName = "char(4)")]
    [Required]
    public string DepotNo { get; set; } = "";

    [Column("dept_name", TypeName = "varchar(40)")]
    [Required]
    public string DeptName { get; set; } = "";
}