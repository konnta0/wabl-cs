using Infrastructure.Pulumi.CI_CD;
using Infrastructure.Pulumi.Component.Shared.CiCd;
using Infrastructure.Pulumi.Component.Shared.ContainerRegistry;
using Infrastructure.Pulumi.Component.Shared.Observability;
using Infrastructure.Pulumi.Component.Tool;
using Infrastructure.Pulumi.Component.Tool.ManagementConsole;
using Infrastructure.Pulumi.Component.WebApplication;
using Infrastructure.Pulumi.VersionControlSystem;
using Pulumi;

namespace Infrastructure.Pulumi.Extension
{
    internal static class PulumiConfigExtension
    {
        internal static bool IsMinikube(this Config config)
        {
            return config.GetBoolean("isMinikube") ?? false;
        }

        internal static ObservabilityConfig GetObservabilityConfig(this Config config)
        {
            return config.GetObject<ObservabilityConfig>("Observability");
        }

        internal static VersionControlSystemConfig GetVersionControlSystemConfig(this Config config)
        {
            return config.GetObject<VersionControlSystemConfig>("VersionControlSystem");
        }

        internal static ContainerRegistryConfig GetContainerRegistryConfig(this Config config)
        {
            return config.GetObject<ContainerRegistryConfig>("ContainerRegistry");
        }

        internal static WebApplicationConfig GetWebApplicationConfig(this Config config)
        {
            return config.GetObject<WebApplicationConfig>("WebApplication");
        }
        
        internal static ToolConfig GetToolConfig(this Config config)
        {
            return config.GetObject<ToolConfig>("Tool");
        }
        
        internal static ManagementConsoleConfig GetManagementConsoleConfig(this Config config)
        {
            return config.GetObject<ManagementConsoleConfig>("ManagementConsole");
        }
    }
}