using ManagementConsole.Infrastructure.Extension.HealthCheck;
using Microsoft.Extensions.DependencyInjection;

namespace ManagementConsole.Infrastructure.Extension;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddHealthChecks().AddChecks();
        
        return serviceCollection;
    }
}