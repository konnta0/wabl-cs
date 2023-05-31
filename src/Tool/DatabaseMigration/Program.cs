using DatabaseMigration;
using DatabaseMigration.Command;
using DatabaseMigration.Command.Seed;
using Infrastructure.Cache;
using Infrastructure.Database;
using Infrastructure.Extension;
using MessagePipe;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = ConsoleApp.CreateBuilder(args);

builder.ConfigureServices((context, collection) =>
{
    context.Configuration.Bind(new SeedServiceConfig());
    
    collection.AddDbContexts(new DatabaseConfig());
    collection.AddCacheClient(new CacheConfig(), out var _);
    collection.AddSingleton<IDbContextHolder, DbContextHolder>();
    collection.AddScoped<ISeedService, SeedService>();
    collection.AddScoped<IGoogleApiHelper, GoogleApiHelper>();
    collection.AddMessagePipe();
});

var app = builder.Build();
app.AddCommands<SeedCreateCommand>();
app.AddCommands<SeedDownloadCommand>();
app.AddCommands<SeedImportCommand>();
app.AddCommands<SeedRenameLabelCommand>();
app.Run();