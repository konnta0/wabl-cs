using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace WebApplication.Infrastructure.Extension;

public static class ApplicationBuilder
{
    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder applicationBuilder)
    {
        //applicationBuilder.UseOpenTelemetryPrometheusScrapingEndpoint();
        return applicationBuilder;
    }

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