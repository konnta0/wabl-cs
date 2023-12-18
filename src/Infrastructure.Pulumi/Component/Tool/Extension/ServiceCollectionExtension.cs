using Infrastructure.Pulumi.Component.Tool.ManagementConsole;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Pulumi.Component.Tool.Extension;

internal static class ServiceCollectionExtension
{
    internal static IServiceCollection AddTool(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ToolComponent>();
        serviceCollection.AddScoped<ManagementConsoleComponent>();
        return serviceCollection;
    }
}