using System.Diagnostics.Metrics;
using ManagementConsole.Infrastructure.Instrumentation;

namespace MessageQueue.Infrastructure.UseCase.Meter;

public interface IUseCaseInstrumentationMeter : IInstrumentationMeter
{
    Counter<int> HealthCheckCounter { get; init; }
}