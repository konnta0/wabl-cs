using WebApplication.Infrastructure.Cache;
using WebApplication.Infrastructure.Database;
using WebApplication.Infrastructure.Extension;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tool.DatabaseMigration.Command.Seed;
using Tool.DatabaseMigration.Domain.Internal.GoogleApi;
using Tool.DatabaseMigration.Domain.Internal.Seed;
using Tool.DatabaseMigration.Domain.Service.Seed;

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