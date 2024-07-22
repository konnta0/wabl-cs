using ConsoleAppFramework;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shared.Infrastructure.Database;
using WebApplication.Infrastructure.Cache;
using Tool.DatabaseMigration.Command.Seed;
using Tool.DatabaseMigration.Domain.Internal.GoogleApi;
using Tool.DatabaseMigration.Domain.Internal.Seed;
using Tool.DatabaseMigration.Domain.Service.Seed;
using WebApplication.Infrastructure.Extension;

using var host = Host
    .CreateDefaultBuilder()
    .ConfigureServices((context, service) =>
    {
        context.Configuration.Bind(new SeedServiceConfig());
        service.AddDbContexts(new DatabaseConfig());
        service.AddCacheClient(new CacheConfig(), out _, out _);
        service.AddScoped<ISeedService, SeedService>();
        service.AddScoped<IGoogleApiHelper, GoogleApiHelper>();
    }).Build();

ConsoleApp.ServiceProvider = host.Services;

var app = ConsoleApp.Create();
app.Add<SeedCreateCommand>();
app.Add<SeedDownloadCommand>();
app.Add<SeedImportCommand>();
app.Add<SeedRenameLabelCommand>();
app.Add<SeedValidateCommand>();
await app.RunAsync(args);