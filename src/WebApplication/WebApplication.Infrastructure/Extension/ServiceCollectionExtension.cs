using System.Text;
using CloudStructures;
using WebApplication.Application.Core.Authentication;
using WebApplication.Application.Core.Database;
using WebApplication.Application.Core.RepositoryHandler;
using WebApplication.Application.Core.RequestHandler;
using Cysharp.Text;
using WebApplication.Infrastructure.Extension.HealthCheck;
using WebApplication.Infrastructure.Extension.Instrumentation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
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
using WebApplication.Infrastructure.Cache;
using WebApplication.Infrastructure.Core.Authentication;
using WebApplication.Infrastructure.Core.Instrumentation;
using WebApplication.Infrastructure.Core.Instrumentation.Repository;
using WebApplication.Infrastructure.Core.Instrumentation.UseCase;
using WebApplication.Infrastructure.Core.Instrumentation.UseCase.Meter;
using WebApplication.Infrastructure.Core.Logging;
using WebApplication.Infrastructure.Core.RequestHandler;
using WebApplication.Infrastructure.Core.Time;
using WebApplication.Infrastructure.Database;
using WebApplication.Infrastructure.Database.Context;
using WebApplication.Infrastructure.Database.Context.Employee;
using WebApplication.Infrastructure.Repository;
using ZLogger;
using ZLogger.Providers;

namespace WebApplication.Infrastructure.Extension;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddHealthChecks().AddChecks();

        return serviceCollection
            .AddRepository()
            .AddTimeProvider(configuration.Get<TimeConfig>()!)
            .AddLogging()
            .AddDbContexts(configuration.Get<DatabaseConfig>()!)
            .AddCacheClient(configuration.Get<CacheConfig>()!, out var volatileRedisConnection, out var durableRedisConnection)
            .AddMemoryDatabase()
            .AddOpenTelemetryTracing(volatileRedisConnection, durableRedisConnection)
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

    public static IServiceCollection AddCacheClient(this IServiceCollection serviceCollection, CacheConfig cacheConfig, out RedisConnection volatileRedisConnection, out RedisConnection durableRedisConnection)
    {
        volatileRedisConnection = RedisConnectionFactory.CreateVolatileConnection(cacheConfig);
        var volatileConnection = volatileRedisConnection;
        serviceCollection.AddTransient<IVolatileRedisProvider>(delegate
        {
            return new VolatileRedisProvider(GlobalLogManager.GetLogger<VolatileRedisProvider>()!, volatileConnection);
        });

        durableRedisConnection = RedisConnectionFactory.CreateVolatileConnection(cacheConfig);
        var durableConnection = durableRedisConnection;
        serviceCollection.AddTransient<IDurableRedisProvider>(delegate
        {
            return new DurableRedisProvider(GlobalLogManager.GetLogger<DurableRedisProvider>()!, durableConnection);
        });
        return serviceCollection;
    }
    
    private static IServiceCollection AddTimeProvider(this IServiceCollection serviceCollection, TimeConfig config)
    {
        var serviceProvider = serviceCollection.BuildServiceProvider();
        serviceCollection.AddScoped<TimeProvider>(_ =>
        {
            var durableRedisProvider = serviceProvider.GetRequiredService<IDurableRedisProvider>();
            var environment = serviceProvider.GetRequiredService<IWebHostEnvironment>();
            return TimeProviderFactory.CreateTimeProvider<ZonedFixedTimeProvider>(environment, config, durableRedisProvider);
        });
        
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