using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ManagementConsole.Internals;

internal sealed class HealthCheck : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new ())
    {
        return Task.FromResult(
            HealthCheckResult.Healthy("A healthy result."));
    }
}