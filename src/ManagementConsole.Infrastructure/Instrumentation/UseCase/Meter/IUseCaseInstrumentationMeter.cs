using System.Diagnostics.Metrics;
using ManagementConsole.Infrastructure.Instrumentation;

namespace WebApplication.Infrastructure.Core.Instrumentation.UseCase.Meter;

public interface IUseCaseInstrumentationMeter : IInstrumentationMeter
{
    Counter<int> HealthCheckCounter { get; init; }
}