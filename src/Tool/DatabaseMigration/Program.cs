using Cysharp.Text;
using DatabaseMigration;
using DatabaseMigration.Command;
using Infrastructure.Core.Logging;
using Infrastructure.Extension;
using MessagePipe;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ZLogger;
using ZLogger.Providers;

Console.WriteLine("Start Database migration");
var builder = ConsoleApp.CreateBuilder(args);
GlobalLogManager.SetLoggerFactory(LoggerFactory.Create(loggingBuilder =>
{
    loggingBuilder.ClearProviders();
    loggingBuilder.SetMinimumLevel(LogLevel.Information);
    loggingBuilder.AddFilter<ZLoggerConsoleLoggerProvider>("Microsoft", LogLevel.None);
    loggingBuilder.AddZLoggerConsole(options =>
    {
        options.EnableStructuredLogging = true;
        var prefixFormat = ZString.PrepareUtf8<LogLevel, DateTime>("[{0}][{1}] ");
        options.PrefixFormatter = (writer, info) =>
            prefixFormat.FormatTo(ref writer, info.LogLevel, info.Timestamp.DateTime.ToLocalTime());
    });
}), "Global");

builder.ConfigureServices((_, collection) =>
{
    collection.AddDbContext();
    collection.AddCacheClient();
    collection.AddScoped<ISeedImporter, SeedImporter>();
    collection.AddScoped<ISeedTruncate, SeedTruncate>();
    collection.AddScoped<ISeedReader, SeedReader>();
    collection.AddMessagePipe();
});

var app = builder.Build();
app.AddCommands<SeedImportCommand>();
app.Run();