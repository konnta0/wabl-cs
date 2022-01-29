using System.Collections.ObjectModel;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Logs;
using ZLogger;

namespace Infrastructure.Core.Instrumentation;

internal sealed class InMemoryLogRecords : Collection<LogRecord>
{
    protected override void InsertItem(int index, LogRecord item)
    {
        var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddZLoggerConsole(options =>
            {
                options.EnableStructuredLogging = true;
                var traceIdName = JsonEncodedText.Encode("TraceID");
                var traceIdValue = item.TraceId.ToHexString();

                options.StructuredLoggingFormatter = (writer, info) =>
                {
                    writer.WriteString(traceIdName, traceIdValue);
                    info.WriteToJsonWriter(writer);
                };
            });
        });
        var logger = loggerFactory.CreateLogger<InMemoryLogRecords>();
        logger.ZLog(item.LogLevel, item.Exception, "Traced:" + item.TraceId);
        loggerFactory.Dispose();
    }
}