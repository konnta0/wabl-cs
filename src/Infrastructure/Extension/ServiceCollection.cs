using Domain.Repository;
using Infrastructure.Context;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using ZLogger;

namespace Infrastructure.Extension;

public static class ServiceCollection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        return serviceCollection
            .AddLogging()
            .AddDbContext()
            .AddOpenTelemetryTracing(configuration)
            .AddOpenTelemetryMetrics(configuration)
            .AddContainer();
    }

    private static IServiceCollection AddLogging(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddLogging(builder =>
        {
            builder.ClearProviders();
            builder.SetMinimumLevel(LogLevel.Debug);
            builder.AddZLoggerConsole(options =>
            {
                options.EnableStructuredLogging = true;
            });
            builder.AddOpenTelemetry(options =>
            {
                options.IncludeScopes = true;
                options.ParseStateValues = true;
                options.IncludeFormattedMessage = true;
                //options.AddConsoleExporter();                
            });
        });
    }

    private static IServiceCollection AddOpenTelemetryTracing(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        return serviceCollection.AddOpenTelemetryTracing(builder =>
        {
            builder.SetResourceBuilder(ResourceBuilder.CreateDefault()
                .AddService(configuration.GetValue<string>("Otlp:ServiceName")));
            builder.AddAspNetCoreInstrumentation(options => { options.RecordException = true; });
            builder.AddHttpClientInstrumentation(options => { options.RecordException = true; });
            builder.AddOtlpExporter(options =>
            {
                options.Endpoint = new Uri(configuration.GetValue<string>("Otlp:Endpoint"));
            });
            // for Debug
            // builder.AddConsoleExporter();
        });
    }

    private static IServiceCollection AddOpenTelemetryMetrics(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        return serviceCollection.AddOpenTelemetryMetrics(builder =>
        {
            builder.SetResourceBuilder(ResourceBuilder.CreateDefault()
                .AddService(configuration.GetValue<string>("Otlp:ServiceName")));
            // TODO :: later
            // builder.AddMeter(MyMeter.Name);
            builder.AddAspNetCoreInstrumentation();
            builder.AddHttpClientInstrumentation();

            // I want to do Otlp, but Grafana Tempo doesn't support it.
            // https://grafana.com/blog/2020/11/17/tracing-with-the-grafana-cloud-agent-and-grafana-tempo/
            // builder.AddOtlpExporter(options =>
            // {
            //     options.Endpoint = new Uri(builder.Configuration.GetValue<string>("Otlp:Endpoint"));
            // });

            builder.AddPrometheusExporter(options =>
            {
                options.StartHttpListener = true;
                options.HttpListenerPrefixes = configuration.GetSection("Prometheus:Endpoints").Get<string[]>();
                options.ScrapeEndpointPath = "/metrics";
                options.ScrapeResponseCacheDurationMilliseconds = 0;
            });
        });
    }

    private static IServiceCollection AddContainer(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IDepartmentsRepository, DepartmentsRepository>();
        // TODO : later
        // serviceCollection.AddSingleton<IMyMeter, MyMeter>();
        // serviceCollection.AddSingleton<IMyCounter, MyCounter>();
        return serviceCollection;
    }

    private static IServiceCollection AddDbContext(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContext<EmployeesContext>(optionsBuilder =>
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));
            optionsBuilder.UseMySql(EmployeesContext.GetConnectionString(), serverVersion)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }, ServiceLifetime.Transient);
        return serviceCollection;
    }
}