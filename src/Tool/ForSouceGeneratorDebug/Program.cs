Console.WriteLine("Hello World!");

// var mc = new ExampleEntity();
// Console.WriteLine(mc);
//
//
//
// [Table("Example")]
// public partial class ExampleEntity
// {
//     public int Fuga { get; set; }
//     public string? Piyo { get; set; }
//
//     public static partial void OnModelCreating(EntityTypeBuilder<ExampleEntity> entityTypeBuilder)
//     {
//         entityTypeBuilder.HasOne<EmployeesEntity>();
//     }
// }
//
// [Table("Hoge")]
// public partial class HogeEntity
// {
//     public int Fuga { get; set; }
//     public string? Piyo { get; set; }
//
//     public static partial void OnModelCreating(EntityTypeBuilder<HogeEntity> entityTypeBuilder)
//     {
//         entityTypeBuilder.HasOne<EmployeesEntity>();
//     }
// }

public class TestAttribute : Attribute 
{
    public TestAttribute(string name) {
        Name = name;
    }

    public string Name { get; }
}