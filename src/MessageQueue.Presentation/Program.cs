using Cysharp.Text;
using MessageQueue.Application.Extension;
using MessageQueue.Domain.Extension;
using MessageQueue.Infrastructure.Extension;
using MessageQueue.Infrastructure.Instrumentation;
using MessageQueue.Presentation.Extension;
using OpenTelemetry.Logs;
using Shared.Infrastructure.Cache;
using Shared.Infrastructure.Logging;
using ZLogger;
using ZLogger.Providers;

var builder = Host.CreateApplicationBuilder(args);
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
    loggingBuilder.AddOpenTelemetry(options =>
    {
        options.IncludeScopes = true;
        options.ParseStateValues = true;
        options.IncludeFormattedMessage = true;
        options.AddInMemoryExporter(new InMemoryLogRecords());
    });
}), "Global");

builder.Configuration.Bind(nameof(CacheConfig),new CacheConfig());

builder.Services.AddDomain();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddPresentation();

var host = builder.Build();
host.Run();