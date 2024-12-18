using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using MasterMemory;
using MessagePack;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shared.Domain.Entity.Employee;

[Table("employees")]
[MemoryTable(nameof(EmployeesEntity)), MessagePackObject(true)]
public partial class EmployeesEntity : IHasSeed, IValidatable<EmployeesEntity>
{
    public enum GenderType
    {
        M,
        F
    }

    [PrimaryKey]
    [Column("emp_no", TypeName = "int")]
    [Required]
    [JsonPropertyName("emp_no")]
    public int EmpNo { get; set; }

    [Column("birth_date", TypeName = "date")]
    [Required]
    [JsonPropertyName("birth_date")]
    public DateTime BirthDate { get; set; }

    [Column("first_name", TypeName = "varchar(14)")]
    [Required]
    [JsonPropertyName("first_name")]
    public string FirstName { get; set; } = string.Empty;

    [Column("last_name", TypeName = "varchar(16)")]
    [Required]
    [JsonPropertyName("last_name")]
    public string LastName { get; set; } = string.Empty;
    
    [Column("gender", TypeName = "enum('M', 'F')")]
    [Required]
    [JsonPropertyName("gender")]
    public GenderType Gender { get; set; }
    
    [Column("hire_date", TypeName = "date")]
    [Required]
    [JsonPropertyName("hire_date")]
    public DateTime HireDate { get; set; }
    
    public static partial void OnModelCreating(EntityTypeBuilder<EmployeesEntity> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(employeesEntity => employeesEntity.EmpNo);
    }

    public void Validate(IValidator<EmployeesEntity> validator)
    {
        validator.Validate(x => x.FirstName.Length <= 14, "FirstName length should be less than or equal to 14");
        validator.Validate(x => x.FirstName.Length >= 1, "FirstName length should be greater than or equal to 1");
        validator.Validate(x => x.LastName.Length <= 16, "LastName length should be less than or equal to 16");
    }
}