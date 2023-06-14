namespace CodeGeneration.Command;

public class EntityModel
{ 
    public string NamespaceName { get; init; } = "Domain.Entity";
    public string EntityName { get; init; }
    public bool HasSeed { get; init; }
}