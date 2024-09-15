using System.Diagnostics.Metrics;

namespace MessageQueue.Infrastructure.Instrumentation.UseCase.Meter;

public interface IUseCaseInstrumentationMeter : IInstrumentationMeter
{
    Counter<int> HealthCheckCounter { get; init; }
}