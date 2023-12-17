using System.Diagnostics.Metrics;

namespace WebApplication.Infrastructure.Core.Instrumentation.UseCase.Meter;

public interface IUseCaseInstrumentationMeter : IInstrumentationMeter
{
    Counter<int> HealthCheckCounter { get; init; }
}