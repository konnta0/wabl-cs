using ManagementConsole.Infrastructure.Extension.HealthCheck;
using Microsoft.Extensions.DependencyInjection;
using Shared.Application.Database;
using Shared.Infrastructure.Database;
using Shared.Infrastructure.Database.Context;

namespace ManagementConsole.Infrastructure.Extension;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddHealthChecks().AddChecks();
        
        return serviceCollection.AddMemoryDatabase();
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
}