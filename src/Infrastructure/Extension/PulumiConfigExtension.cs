using Infrastructure.CI_CD;
using Infrastructure.Component.Shared.Observability;
using Infrastructure.ContainerRegistry;
using Infrastructure.Resource.Shared.Observability;
using Infrastructure.VersionControlSystem;
using Infrastructure.WebApplication;
using Pulumi;

namespace Infrastructure.Extension
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

        internal static CICDConfig GetCICDConfig(this Config config)
        {
            return config.GetObject<CICDConfig>("CICD");
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
    }
}