using Pulumi.Crds.Certmanager.V1;
using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Pulumi.Component.Shared.Certificate
{
    public sealed class CertificateComponentInput : IComponentInput
    {
        public Namespace Namespace { get; init; } = null!;
    }

    public sealed class CertificateComponentOutput : IComponentOutput
    {
        public ClusterIssuer ClusterIssuer { get; init; } = null!;
    }
}