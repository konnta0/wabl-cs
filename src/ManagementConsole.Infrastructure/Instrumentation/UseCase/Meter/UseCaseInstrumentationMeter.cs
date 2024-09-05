using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace ManagementConsole.Infrastructure.Instrumentation.UseCase.Meter;

public class UseCaseInstrumentationMeter : IUseCaseInstrumentationMeter
{
    public Counter<int> HealthCheckCounter { get; init; }
    
    
    public UseCaseInstrumentationMeter()
    {
        var meter = new System.Diagnostics.Metrics.Meter(nameof(UseCaseInstrumentationMeter));
        meter.CreateObservableCounter("thread.cpu_time", () => GetThreadCpuTime(Process.GetCurrentProcess()));
        HealthCheckCounter = meter.CreateCounter<int>(nameof(HealthCheckCounter), description: "This is demo");
    }

    private static IEnumerable<Measurement<double>> GetThreadCpuTime(Process process)
    {
        foreach (ProcessThread thread in process.Threads)
        {
            yield return new Measurement<double>(thread.TotalProcessorTime.TotalMilliseconds, new KeyValuePair<string, object?>("ProcessId", process.Id), new KeyValuePair<string, object?>("ThreadId", thread.Id));
        }
    }

}