using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using MasterMemory;
using MessagePack;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entity.Employee;

[Table("titles")]
[MemoryTable(nameof(TitlesEntity)), MessagePackObject(true)]
public partial class TitlesEntity : IHasSeed, IValidatable<TitlesEntity>
{
    [System.ComponentModel.DataAnnotations.Key]
    [PrimaryKey(keyOrder: 0)]
    [Column("emp_no", TypeName = "int")]
    [JsonPropertyName("emp_no")]
    [Required]
    public int EmpNo { get; set; } = 0;

    [Column("title", TypeName = "varchar(50)")]
    [JsonPropertyName("title")]
    [Required]
    public string Title { get; set; } = "";
    
    [PrimaryKey(keyOrder: 1)]
    [Column("from_date", TypeName = "date")]
    [JsonPropertyName("from_date")]
    [Required]
    public DateTime FromDate { get; set; }
    
    [Column("to_date", TypeName = "date")]
    [JsonPropertyName("to_date")]
    [Required]
    public DateTime ToDate { get; set; }

    public static partial void OnModelCreating(EntityTypeBuilder<TitlesEntity> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(titlesEntity => new { titlesEntity.EmpNo, titlesEntity.FromDate });
        entityTypeBuilder.HasOne<EmployeesEntity>();
    }

    public void Validate(IValidator<TitlesEntity> validator)
    {
        var employees = validator.GetReferenceSet<EmployeesEntity>();
        
        employees.Exists(x => x.EmpNo, x => x.EmpNo);
    }
}