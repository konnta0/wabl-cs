using DatabaseMigration.Command.Seed;
using DatabaseMigration.Domain.Internal.GoogleApi;
using DatabaseMigration.Domain.Internal.Seed;
using DatabaseMigration.Domain.Service.Seed;
using Infrastructure.Cache;
using Infrastructure.Database;
using Infrastructure.Extension;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = ConsoleApp.CreateBuilder(args);

builder.ConfigureServices((context, collection) =>
{
    context.Configuration.Bind(new SeedServiceConfig());
    
    collection.AddDbContexts(new DatabaseConfig());
    collection.AddCacheClient(new CacheConfig(), out _, out _);
    collection.AddScoped<ISeedService, SeedService>();
    collection.AddScoped<IGoogleApiHelper, GoogleApiHelper>();
});

var app = builder.Build();
app.AddCommands<SeedCreateCommand>();
app.AddCommands<SeedDownloadCommand>();
app.AddCommands<SeedImportCommand>();
app.AddCommands<SeedRenameLabelCommand>();
app.AddCommands<SeedValidateCommand>();
app.Run();