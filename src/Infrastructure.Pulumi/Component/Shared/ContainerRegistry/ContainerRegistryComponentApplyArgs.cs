using Pulumi.Crds.Certmanager.V1;
using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Pulumi.Component.Shared.ContainerRegistry
{
    public sealed class ContainerRegistryComponentInput : IComponentInput
    {
        public Namespace Namespace { get; set; } = null!;
        public ClusterIssuer ClusterIssuer { get; set; } = null!;
    }

    public sealed class ContainerRegistryComponentOutput : IComponentOutput
    {
    }
}