using CloudStructures;
using MessageQueue.Application;
using MessageQueue.Application.RequestHandler;
using MessageQueue.Domain.DataTransferObject;
using MessageQueue.Infrastructure.Extension.Instrumentation;
using MessageQueue.Infrastructure.Instrumentation.Repository;
using MessageQueue.Infrastructure.Instrumentation.UseCase;
using MessageQueue.Infrastructure.PubSub;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Shared.Infrastructure.Cache;
using Shared.Infrastructure.Extension;

namespace MessageQueue.Infrastructure.Extension;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection
            .AddSingleton<IConsumerFactory<KpiLog>, KpiLogConsumerFactory>()
            .AddCacheClient(configuration.Get<CacheConfig>()!, out var volatileRedisConnection, out var durableRedisConnection)
            .AddOpenTelemetryTracing(volatileRedisConnection, durableRedisConnection);
        return serviceCollection;
    }

    private static IServiceCollection AddOpenTelemetryTracing(this IServiceCollection serviceCollection, RedisConnection volatileConnection, RedisConnection durableConnection)
    {
        
        return serviceCollection.AddOpenTelemetry().WithTracing(builder =>
        {
            builder.SetResourceBuilder(ResourceBuilder.CreateDefault()
                .AddService(Environment.GetEnvironmentVariable("OTLP_SERVER_NAME")!));
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

            builder.AddRedisInstrumentation(volatileConnection.GetConnection(), options =>
            {
                options.FlushInterval = TimeSpan.FromSeconds(1);
                options.SetVerboseDatabaseStatements = true;
                options.Enrich = (activity, command) =>
                {
                    activity.SetTag("type", "volatile");
                    activity.SetTag("is_fast", command.ElapsedTime < TimeSpan.FromMilliseconds(100));
                };
            });
            
            builder.AddRedisInstrumentation(durableConnection.GetConnection(), options =>
            {
                options.FlushInterval = TimeSpan.FromSeconds(1);
                options.SetVerboseDatabaseStatements = true;
                options.Enrich = (activity, command) =>
                {
                    activity.SetTag("type", "durable");
                    activity.SetTag("is_fast", command.ElapsedTime < TimeSpan.FromMilliseconds(100));
                };
            });
        })
            .Services.AddScoped<IUseCaseActivityStarter, UseCaseActivityStarter>()
            .AddScoped<IRepositoryActivityStarter, RepositoryActivityStarter>();
    }
}