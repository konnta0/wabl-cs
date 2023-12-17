using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using WebApplication.Infrastructure.Core.HealthCheck;

namespace WebApplication.Infrastructure.Extension.HealthCheck;

internal static class HealthChecksBuilderExtension
{
    internal static IHealthChecksBuilder AddChecks(this IHealthChecksBuilder builder)
    {
        builder.AddCheck<ApiHealthCheck>(
            nameof(ApiHealthCheck), 
            HealthStatus.Degraded,
            new[] { "api" });
        return builder;
    }
}