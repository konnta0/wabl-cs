using Pulumi.Crds.Certmanager.V1;
using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Pulumi.Component.Shared.ContainerRegistry
{
    public sealed class ContainerRegistryComponentInput : IComponentInput
    {
        public required Namespace Namespace { get; init; }
        public required ClusterIssuer ClusterIssuer { get; init; }
    }

    public sealed class ContainerRegistryComponentOutput : IComponentOutput
    {
    }
}