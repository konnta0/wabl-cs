using Microsoft.Extensions.DependencyInjection;

namespace ManagementConsole.Application.Extension;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services;
    }
}