namespace CodeGeneration.Command;

public class EntityModel
{ 
    public string NamespaceName { get; init; } = "Domain.Entity";
    public string EntityName { get; init; }
    public List<string> Implements { get; init; } = new();
    public string ImplementsNames => string.Join(", ", Implements);
}