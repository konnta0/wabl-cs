using Infrastructure.Observability;
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
    }
}