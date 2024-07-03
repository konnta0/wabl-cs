using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ManagementConsole.Infrastructure.Core.HealthCheck;

internal sealed class ManagementConsoleHealthCheck : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new ())
    {
        return Task.FromResult(
            HealthCheckResult.Healthy("A healthy result."));
    }
}