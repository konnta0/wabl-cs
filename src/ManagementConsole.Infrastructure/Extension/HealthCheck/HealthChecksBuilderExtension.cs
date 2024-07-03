using ManagementConsole.Infrastructure.Core.HealthCheck;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ManagementConsole.Infrastructure.Extension.HealthCheck;

internal static class HealthChecksBuilderExtension
{
    internal static IHealthChecksBuilder AddChecks(this IHealthChecksBuilder builder)
    {
        builder.AddCheck<ManagementConsoleHealthCheck>(
            nameof(ManagementConsoleHealthCheck), 
            HealthStatus.Degraded,
            ["tool", "management-console"]);
        return builder;
    }
}