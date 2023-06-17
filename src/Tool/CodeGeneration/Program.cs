using CodeGeneration;
using CodeGeneration.Command;
using Microsoft.Extensions.Configuration;

var builder = ConsoleApp.CreateBuilder(args);

builder.ConfigureServices((context, collection) =>
{
    context.Configuration.Bind(new CodeGenerationConfig());
    context.Configuration.Bind(new EntityModel());
});

var app = builder.Build();
app.AddCommands<GenerateCodeCommand>();
app.Run();