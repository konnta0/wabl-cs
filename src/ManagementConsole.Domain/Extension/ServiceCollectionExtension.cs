using Microsoft.Extensions.DependencyInjection;

namespace ManagementConsole.Domain.Extension;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        return services;
    }
}