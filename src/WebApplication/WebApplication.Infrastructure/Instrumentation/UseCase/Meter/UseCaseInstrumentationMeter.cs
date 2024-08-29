using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace WebApplication.Infrastructure.Instrumentation.UseCase.Meter;

public class UseCaseInstrumentationMeter : IUseCaseInstrumentationMeter
{
    private readonly System.Diagnostics.Metrics.Meter _meter;

    public Counter<int> HealthCheckCounter { get; init; }
    
    
    public UseCaseInstrumentationMeter()
    {
        _meter = new System.Diagnostics.Metrics.Meter(nameof(UseCaseInstrumentationMeter));
        _meter.CreateObservableCounter("thread.cpu_time", () => GetThreadCpuTime(Process.GetCurrentProcess()));
        HealthCheckCounter = _meter.CreateCounter<int>(nameof(HealthCheckCounter), description: "This is demo");
    }

    private static IEnumerable<Measurement<double>> GetThreadCpuTime(Process process)
    {
        foreach (ProcessThread thread in process.Threads)
        {
            yield return new Measurement<double>(thread.TotalProcessorTime.TotalMilliseconds, new KeyValuePair<string, object?>("ProcessId", process.Id), new KeyValuePair<string, object?>("ThreadId", thread.Id));
        }
    }

}