using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entity.Employee;

[Table("employees")]
public partial class EmployeesModel
{
    public enum GenderType
    {
        M,
        F
    }

    [Column("emp_no", TypeName = "int")]
    [Required]
    public int EmpNo { get; set; }

    [Column("birth_date", TypeName = "date")]
    [Required]
    public DateTime BirthDate { get; set; }

    [Column("first_name", TypeName = "varchar(14)")]
    [Required]
    public string FirstName { get; set; } = string.Empty;

    [Column("last_name", TypeName = "varchar(16)")]
    [Required]
    public string LastName { get; set; } = string.Empty;
    
    [Column("gender", TypeName = "enum('M', 'F')")]
    [Required]
    public GenderType Gender { get; set; }
    
    [Column("hire_date", TypeName = "date")]
    [Required]
    public DateTime HireDate { get; set; }
    
    public static partial void OnModelCreating(EntityTypeBuilder<EmployeesModel> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(x => x.EmpNo);
    }
}