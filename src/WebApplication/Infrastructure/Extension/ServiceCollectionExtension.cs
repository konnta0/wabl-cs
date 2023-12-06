using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Text;
using System.Text.Json;
using CloudStructures;
using WebApplication.Application.Core.Authentication;
using WebApplication.Application.Core.Database;
using WebApplication.Application.Core.RepositoryHandler;
using WebApplication.Application.Core.RequestHandler;
using Cysharp.Text;
using Domain;
using Infrastructure.Cache;
using Infrastructure.Core.Authentication;
using Infrastructure.Core.Instrumentation;
using Infrastructure.Core.Instrumentation.Repository;
using Infrastructure.Core.Instrumentation.UseCase;
using Infrastructure.Core.Instrumentation.UseCase.Meter;
using Infrastructure.Core.Logging;
using Infrastructure.Core.RequestHandler;
using Infrastructure.Core.Time;
using Infrastructure.Database;
using Infrastructure.Database.Context;
using Infrastructure.Database.Context.Employee;
using Infrastructure.Extension.HealthCheck;
using Infrastructure.Extension.Instrumentation;
using Infrastructure.Repository;
using MasterMemory;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Polly;
using Polly.Extensions.Http;
using StackExchange.Redis;
using ZLogger;
using ZLogger.Providers;

namespace Infrastructure.Extension;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddHealthChecks().AddChecks();

        return serviceCollection
            .AddRepository()
            .AddDateTimeHandler()
            .AddLogging()
            .AddDbContexts(configuration.Get<DatabaseConfig>()!)
            .AddCacheClient(configuration.Get<CacheConfig>()!, out var connectionMultiplexer)
            .AddMemoryDatabase()
            .AddOpenTelemetryTracing(connectionMultiplexer)
            .AddOpenTelemetryMetrics(configuration.Get<InstrumentationConfig>()!)
            .AddAuthentication(configuration.Get<AuthenticationConfig>()!);
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

    private static IServiceCollection AddOpenTelemetryTracing(this IServiceCollection serviceCollection, RedisConnection redisConnection)
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
            
            builder.AddRedisInstrumentation(redisConnection.GetConnection(), options =>
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
        }).Services.AddScoped<IUseCaseActivityStarter, UseCaseActivityStarter>()
            .AddScoped<IRepositoryActivityStarter, RepositoryActivityStarter>();
    }

    private static IServiceCollection AddOpenTelemetryMetrics(this IServiceCollection serviceCollection, InstrumentationConfig instrumentationConfig)
    {
        return serviceCollection.AddOpenTelemetry().WithMetrics(builder => 
        {
            builder.SetResourceBuilder(ResourceBuilder.CreateDefault().AddService(instrumentationConfig.ServiceName));
            builder.AddWebApplicationInstrumentation();
            builder.AddAspNetCoreInstrumentation();
            builder.AddHttpClientInstrumentation();

            builder.AddOtlpExporter(options =>
            {
                options.Endpoint = new Uri(instrumentationConfig.Endpoint);
            });
            
        }).Services.AddSingleton<IUseCaseInstrumentationMeter, UseCaseInstrumentationMeter>();
    }

    public static IServiceCollection AddDbContexts(this IServiceCollection serviceCollection, DatabaseConfig databaseConfig)
    {
        // TODO: https://learn.microsoft.com/ja-jp/ef/core/performance/advanced-performance-topics?tabs=with-di%2Cexpression-api-with-constant
        // TODO: connection pool. create context factory.
        // serviceCollection.AddDbContext<EmployeesContext>(optionsBuilder =>
        // { 
        //     var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));
        //     optionsBuilder.UseMySql(
        //             EmployeesContext.GetConnectionString(databaseConfig),
        //             serverVersion,
        //             mySqlOptionsAction =>
        //             {
        //                 mySqlOptionsAction.MigrationsAssembly("DatabaseMigration");
        //                 mySqlOptionsAction.EnableRetryOnFailure(3, TimeSpan.FromSeconds(3), null);
        //             })
        //         .EnableSensitiveDataLogging()
        //         .EnableDetailedErrors();
        // });
        serviceCollection.AddDbContextPool<EmployeesContext>(optionsAction =>
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));
            optionsAction.UseMySql(
                    EmployeesContext.GetConnectionString(databaseConfig),
                    serverVersion,
                    mySqlOptionsAction =>
                    {
                        mySqlOptionsAction.MigrationsAssembly("DatabaseMigration");
                        mySqlOptionsAction.EnableRetryOnFailure(3, TimeSpan.FromSeconds(3), null);
                    })
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        });
        
        serviceCollection.AddScoped<IDbContextHolder, DbContextHolder>();
        serviceCollection.AddTransient<ITransactionalFlow, TransactionalFlow>();

        return serviceCollection;
    }

    private static MeterProviderBuilder AddWebApplicationInstrumentation(this MeterProviderBuilder meterProviderBuilder)
    {
        meterProviderBuilder.AddMeter(nameof(UseCaseInstrumentationMeter));
        return meterProviderBuilder;
    }

    public static IServiceCollection AddCacheClient(this IServiceCollection serviceCollection, CacheConfig cacheConfig, out RedisConnection connection)
    {
        connection = RedisConnectionFactory.CreateVolatileConnection(cacheConfig);
        var redisConnection = connection;
        serviceCollection.AddTransient<IVolatileRedisProvider>(delegate
        {
            return new VolatileRedisProvider(GlobalLogManager.GetLogger<VolatileRedisProvider>()!, redisConnection);
        });
        serviceCollection.AddSingleton(redisConnection);
        return serviceCollection;
    }
    
    private static IServiceCollection AddDateTimeHandler(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IDateTimeHandler, ZonedFixedTimeProvider>();
        return serviceCollection;
    }
    
    private static IServiceCollection AddRepository(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IRepositoryHandler, RepositoryHandler>();
        serviceCollection.AddSingleton<IRepositoryInputTypeResolver, RepositoryInputTypeResolver>();
        return serviceCollection;
    }
    
    private static IServiceCollection AddMemoryDatabase(this IServiceCollection serviceCollection)
    {
        var provider = serviceCollection.BuildServiceProvider();
        var dbContextHolder = provider.GetRequiredService<IDbContextHolder>();
        
        var memoryDatabaseProvider = new MemoryDatabaseProvider();
        var memoryDatabaseLoader = new MemoryDatabaseLoader(dbContextHolder, memoryDatabaseProvider);

        serviceCollection.AddSingleton<IMemoryDatabaseProvider>(_ => memoryDatabaseProvider);
        serviceCollection.AddSingleton<IMemoryDatabaseHolder>(_ => memoryDatabaseProvider);
        serviceCollection.AddScoped<IMemoryDatabaseLoader>(_ => memoryDatabaseLoader);
        return serviceCollection;
    }

    private static IServiceCollection AddAuthentication(this IServiceCollection serviceCollection, AuthenticationConfig authenticationConfig)
    {
        serviceCollection.AddAuthentication(static options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = authenticationConfig.Issuer,
                ValidAudience = authenticationConfig.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationConfig.Secret))
            };
        });

        serviceCollection.AddHttpClient<IAuthenticationProvider, AuthenticationProvider>()
            .AddPolicyHandler(HttpPolicyExtensions.HandleTransientHttpError().WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))));
        return serviceCollection;
    }
}