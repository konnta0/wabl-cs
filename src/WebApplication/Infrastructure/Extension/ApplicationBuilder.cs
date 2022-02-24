using Microsoft.AspNetCore.Builder;

namespace Infrastructure.Extension;

public static class ApplicationBuilder
{
    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder applicationBuilder)
    {
        applicationBuilder.UseOpenTelemetryPrometheusScrapingEndpoint();
        return applicationBuilder;
    }
}