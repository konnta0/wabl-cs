using DatabaseMigration;
using DatabaseMigration.Command;
using Infrastructure.Extension;
using MessagePipe;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Start Database migration");
var builder = ConsoleApp.CreateBuilder(args);
builder.ConfigureServices((_, collection) =>
{
    collection.AddDbContext();
    collection.AddCacheClient();
    collection.AddScoped<ISeedImporter, SeedImporter>();
    collection.AddScoped<ISeedReader, SeedReader>();
    collection.AddMessagePipe();
});

var app = builder.Build();
ConsoleApp.Run<SeedImportCommand>(args);
