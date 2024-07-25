namespace ManagementConsole.Infrastructure.Instrumentation;

public class InstrumentationConfig
{
    public string ServiceName { get; init; } = Environment.GetEnvironmentVariable("OTLP_SERVER_NAME")!;
    public string Endpoint { get; init; } = Environment.GetEnvironmentVariable("OTLP_ENDPOINT")!;
}