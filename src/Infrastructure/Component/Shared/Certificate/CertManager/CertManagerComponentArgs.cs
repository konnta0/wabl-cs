using Pulumi.Crds.Certmanager.V1;
using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Component.Shared.Certificate.CertManager
{
    public sealed class CertManagerComponentInput : IComponentInput
    {
        public Namespace Namespace { get; init; } = null!;
    }

    public sealed class CertManagerComponentOutput : IComponentOutput
    {
        public ClusterIssuer ClusterIssuer { get; init; } = null!;
    }
}