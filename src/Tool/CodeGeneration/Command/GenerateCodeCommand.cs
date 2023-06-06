namespace CodeGeneration.Command;

public class GenerateCodeCommand : ConsoleAppBase
{
    [Command("generate-entity")]
    public ValueTask GenerateEntityAsync()
    {
        return default;
    }
}