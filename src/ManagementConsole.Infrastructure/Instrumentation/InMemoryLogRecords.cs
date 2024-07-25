using System.Collections.ObjectModel;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Logs;
using ZLogger;

namespace ManagementConsole.Infrastructure.Instrumentation;

public sealed class InMemoryLogRecords : Collection<LogRecord>
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

                var spanIdName = JsonEncodedText.Encode("SpanID");
                var spanIdValue = item.SpanId.ToHexString();
                
                options.StructuredLoggingFormatter = (writer, _) =>
                {
                    var copiedLogInfo = new LogInfo(item.CategoryName!, item.Timestamp, item.LogLevel, item.EventId,
                        item.Exception);
                    writer.WriteString(traceIdName, traceIdValue);
                    writer.WriteString(spanIdName, spanIdValue);
                    copiedLogInfo.WriteToJsonWriter(writer);
                };
            });
        });
        var logger = loggerFactory.CreateLogger<InMemoryLogRecords>();
        logger.ZLog(item.LogLevel, item.Exception, item.FormattedMessage!);
        loggerFactory.Dispose();
    }
}