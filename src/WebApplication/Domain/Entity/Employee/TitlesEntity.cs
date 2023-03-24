using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entity.Employee;

[Table("titles")]
public partial class TitlesEntity
{
    [Key]
    [Column("emp_no", TypeName = "int")]
    [JsonPropertyName("emp_no")]
    [Required]
    public int EmpNo { get; set; } = 0;

    [Column("title", TypeName = "varchar(50)")]
    [JsonPropertyName("title")]
    [Required]
    public string Title { get; set; } = "";
    
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
}