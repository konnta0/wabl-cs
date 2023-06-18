using Microsoft.Extensions.Logging;
using RazorEngineCore;
using ZLogger;

namespace CodeGeneration.Command;

public class GenerateCodeCommand : ConsoleAppBase
{
    private readonly ILogger<GenerateCodeCommand> _logger;

    public GenerateCodeCommand(ILogger<GenerateCodeCommand> logger)
    {
        _logger = logger;
    }

    [Command("generate-entity")]
    public async ValueTask GenerateEntityAsync(
        [Option("e")] string entityName,
        [Option("ns")] string namespaceName = "Domain.Entity",
        [Option("o")] string outputPath = "src/WebApplication/Domain/Entity")
    {
        var model = new EntityModel
        {
            NamespaceName = namespaceName,
            EntityName = entityName + "Entity",
            Implements = new List<string>
            {
                "IEntity",
                "IHasSeed"
            }
        };
        _logger.ZLogInformationWithPayload(model, "Start Generate Entity");

        var razorEngine = new RazorEngineCore.RazorEngine();
        var templateText = await File.ReadAllTextAsync("Template/EntityTemplate.cshtml");
        var template = await razorEngine.CompileAsync<RazorEngineTemplateBase<EntityModel>>(templateText);
        var result = await template.RunAsync(instance =>
        {
            instance.Model = model;
        });

        if (result is null)
        {
            throw new InvalidOperationException("Generate Entity Failed");
        }
        
        Console.WriteLine(result);
        
        // write file in outputPath
        if (!Directory.Exists(outputPath))
        {
            Directory.CreateDirectory(outputPath);
        }
        var fileName = $"{entityName}.g.cs";
        var filePath = Path.Combine(outputPath, fileName);
        await File.WriteAllTextAsync(filePath, result);

        _logger.ZLogInformation($"Generated Entity: {entityName}. Write to {filePath}/{fileName}");
    }
}