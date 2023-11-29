using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ManagementConsole.Internals.Extension;

internal static class ApplicationBuilderExtension
{
    public static IApplicationBuilder UseHealthChecks(this IApplicationBuilder applicationBuilder)
    {
        return applicationBuilder.UseHealthChecks("/healthz", new HealthCheckOptions
        {
            AllowCachingResponses = false,
            ResultStatusCodes =
            {
                [HealthStatus.Healthy] = StatusCodes.Status200OK,
                [HealthStatus.Degraded] = StatusCodes.Status200OK,
                [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
            }
        });
    }
}