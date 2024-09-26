using Microsoft.Extensions.Diagnostics.HealthChecks;
using WebApplication.Infrastructure.Instrumentation.UseCase.Meter;

namespace WebApplication.Infrastructure.HealthCheck;

internal class ApiHealthCheck(IUseCaseInstrumentationMeter useCaseInstrumentationMeter) : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new())
    {
        var isHealthy = true;

        if (isHealthy)
        {
            useCaseInstrumentationMeter.HealthCheckCounter.Add(1, new KeyValuePair<string, object?>("healthy", bool.TrueString));
            return Task.FromResult(
                HealthCheckResult.Healthy("A healthy result."));
        }

        useCaseInstrumentationMeter.HealthCheckCounter.Add(1, new KeyValuePair<string, object?>("healthy", bool.FalseString));
        return Task.FromResult(
            new HealthCheckResult(
                context.Registration.FailureStatus, "An unhealthy result."));
    }
}