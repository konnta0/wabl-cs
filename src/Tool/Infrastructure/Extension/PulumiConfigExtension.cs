using Pulumi;

namespace Infrastructure.Extension
{
    internal static class PulumiConfigExtension
    {
        internal static bool IsMinikube(this Config config)
        {
            return config.GetBoolean("isMinikube") ?? false;
        }
    }
}