using System.Diagnostics.Metrics;

namespace ManagementConsole.Infrastructure.Instrumentation.UseCase.Meter;

public interface IUseCaseInstrumentationMeter : IInstrumentationMeter
{
    Counter<int> HealthCheckCounter { get; init; }
}