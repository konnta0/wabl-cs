using DatabaseMigration;
using DatabaseMigration.Command;
using Infrastructure.Cache;
using Infrastructure.Database;
using Infrastructure.Extension;
using MessagePipe;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Start Database migration");
var builder = ConsoleApp.CreateBuilder(args);

builder.ConfigureServices((_, collection) =>
{
    collection.AddDbContexts(new DatabaseConfig());
    collection.AddCacheClient(new CacheConfig(), out var _);
    collection.AddSingleton<IDbContextHolder, DbContextHolder>();
    collection.AddMessagePipe();
});

var app = builder.Build();
app.AddCommands<SeedImportCommand>();
app.Run();