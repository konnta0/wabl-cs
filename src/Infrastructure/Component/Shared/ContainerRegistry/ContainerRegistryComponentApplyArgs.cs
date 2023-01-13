using Pulumi.Crds.Certmanager.V1;
using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Component.Shared.ContainerRegistry
{
    public sealed class ContainerRegistryComponentInput : IComponentInput
    {
        public Namespace Namespace { get; set; }
        public ClusterIssuer ClusterIssuer { get; set; }
    }

    public sealed class ContainerRegistryComponentOutput : IComponentOutput
    {
    }
}