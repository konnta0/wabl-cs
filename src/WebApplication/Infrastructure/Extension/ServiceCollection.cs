using Cysharp.Text;
using Domain.Repository.Department;
using Infrastructure.Cache;
using Infrastructure.Core.Instrumentation;
using Infrastructure.Core.Instrumentation.UseCase.Meter;
using Infrastructure.Core.Logging;
using Infrastructure.Core.RequestHandler;
using Infrastructure.Database.Context.Employee;
using Infrastructure.Extension.HealthCheck;
using Infrastructure.Extension.Instrumentation;
using Infrastructure.Repository.Departments;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using ZLogger;
using ZLogger.Providers;

namespace Infrastructure.Extension;

public static class ServiceCollection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddHealthChecks().AddChecks();
            
        return serviceCollection
            .AddLogging()
            .AddDbContext()
            .AddOpenTelemetryTracing(configuration)
            .AddOpenTelemetryMetrics(configuration)
            .AddContainer();
    }

    private static IServiceCollection AddLogging(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddHttpLogging(options => { options.LoggingFields = HttpLoggingFields.All; })
            .AddLogging(builder =>
            {
                builder.ClearProviders();
                builder.SetMinimumLevel(LogLevel.Information);
                builder.AddFilter<ZLoggerConsoleLoggerProvider>("Microsoft", LogLevel.None);
                builder.AddZLoggerConsole(options =>
                {
                    options.EnableStructuredLogging = true;
                    var prefixFormat = ZString.PrepareUtf8<LogLevel, DateTime>("[{0}][{1}] ");
                    options.PrefixFormatter = (writer, info) => prefixFormat.FormatTo(ref writer, info.LogLevel, info.Timestamp.DateTime.ToLocalTime());
                });
                builder.AddOpenTelemetry(options =>
                {
                    options.IncludeScopes = true;
                    options.ParseStateValues = true;
                    options.IncludeFormattedMessage = true;
                    options.AddInMemoryExporter(new InMemoryLogRecords());
                });
            });
    }

    private static IServiceCollection AddOpenTelemetryTracing(this IServiceCollection serviceCollection, IConfiguration configuration)
    {

        return serviceCollection.AddOpenTelemetryTracing(builder =>
        {
            builder.SetResourceBuilder(ResourceBuilder.CreateDefault()
                .AddService(Environment.GetEnvironmentVariable("OTLP_SERVER_NAME")));
            builder.AddAspNetCoreInstrumentation(options =>
            {
                options.RecordException = true;
            });
            builder.AddHttpClientInstrumentation(options => { options.RecordException = true; });
            builder.AddOtlpExporter(options =>
            {
                options.Endpoint = new Uri(Environment.GetEnvironmentVariable("OTLP_ENDPOINT") ?? string.Empty);
            });
            builder.AddEntityFrameworkCoreInstrumentation(options =>
            {
                options.SetDbStatementForText = true;
            });
            builder.AddRepositoryInstrumentation();
            builder.AddUseCaseInstrumentation();
            
            var connection = CacheClientFactory.CreateVolatileCacheConnectionMultiplexer();
            serviceCollection.AddTransient<IVolatileCacheClient>(delegate
            {
                return new VolatileCacheClient(GlobalLogManager.GetLogger<VolatileCacheClient>(), connection);
            });
            serviceCollection.AddSingleton(connection);
            builder.AddRedisInstrumentation(connection, options =>
            {
                options.FlushInterval = TimeSpan.FromSeconds(1);
                options.SetVerboseDatabaseStatements = true;
                options.Enrich = (activity, command) =>
                {
                    if (command.ElapsedTime < TimeSpan.FromMilliseconds(100))
                    {
                        activity.SetTag("is_fast", true);
                    }
                };
            });
        });
    }

    private static IServiceCollection AddOpenTelemetryMetrics(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        return serviceCollection.AddOpenTelemetryMetrics(builder =>
        {
            builder.SetResourceBuilder(ResourceBuilder.CreateDefault()
                .AddService(Environment.GetEnvironmentVariable("OTLP_SERVER_NAME")));
            builder.AddWebApplicationInstrumentation();
            builder.AddAspNetCoreInstrumentation();
            builder.AddHttpClientInstrumentation();

            builder.AddOtlpExporter(options =>
            {
                options.Endpoint = new Uri(Environment.GetEnvironmentVariable("OTLP_ENDPOINT") ?? string.Empty);
            });
            
        }).AddSingleton<IUseCaseInstrumentationMeter, UseCaseInstrumentationMeter>();
    }

    private static IServiceCollection AddContainer(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IAsyncRepositoryHandler<IDepartmentRepositoryInputData, IDepartmentRepositoryOutputData?>, AsyncDepartmentRepositoryHandler>();
        return serviceCollection;
    }

    public static IServiceCollection AddDbContext(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContext<EmployeesContext>(optionsBuilder =>
        { 
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));
            optionsBuilder.UseMySql(EmployeesContext.GetConnectionString(), serverVersion, builder => builder.MigrationsAssembly("DatabaseMigration"))
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }, ServiceLifetime.Transient);
        return serviceCollection;
    }

    private static MeterProviderBuilder AddWebApplicationInstrumentation(this MeterProviderBuilder meterProviderBuilder)
    {
        // builder.AddMeter(MyMeter.Name);
        meterProviderBuilder.AddMeter(nameof(UseCaseInstrumentationMeter));
        return meterProviderBuilder;
    }

    public static IServiceCollection AddCacheClient(this IServiceCollection serviceCollection)
    {
        var connection = CacheClientFactory.CreateVolatileCacheConnectionMultiplexer();
        serviceCollection.AddTransient<IVolatileCacheClient>(delegate
        {
            return new VolatileCacheClient(GlobalLogManager.GetLogger<VolatileCacheClient>(), connection);
        });
        serviceCollection.AddSingleton(connection);
        return serviceCollection;
    }
}