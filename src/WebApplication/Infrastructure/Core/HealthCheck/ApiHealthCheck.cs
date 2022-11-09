using Infrastructure.Core.Instrumentation.UseCase.Meter;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Infrastructure.Core.HealthCheck;

internal class ApiHealthCheck : IHealthCheck
{
    private readonly IUseCaseInstrumentationMeter _useCaseInstrumentationMeter;

    public ApiHealthCheck(IUseCaseInstrumentationMeter useCaseInstrumentationMeter)
    {
        _useCaseInstrumentationMeter = useCaseInstrumentationMeter;
    }

    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new())
    {
        var isHealthy = true;
        
        if (isHealthy)
        {
            _useCaseInstrumentationMeter.HealthCheckCounter.Add(1, new KeyValuePair<string, object?>("healthy", bool.TrueString));
            return Task.FromResult(
                HealthCheckResult.Healthy("A healthy result."));
        }

        _useCaseInstrumentationMeter.HealthCheckCounter.Add(1, new KeyValuePair<string, object?>("healthy", bool.FalseString));
        return Task.FromResult(
            new HealthCheckResult(
                context.Registration.FailureStatus, "An unhealthy result."));
    }
}