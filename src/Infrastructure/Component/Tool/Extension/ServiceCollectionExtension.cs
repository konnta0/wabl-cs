using Infrastructure.Component.Tool.ManagementConsole;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Component.Tool.Extension;

internal static class ServiceCollectionExtension
{
    internal static IServiceCollection AddTool(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ToolComponent>();
        serviceCollection.AddScoped<ManagementConsoleComponent>();
        return serviceCollection;
    }
}