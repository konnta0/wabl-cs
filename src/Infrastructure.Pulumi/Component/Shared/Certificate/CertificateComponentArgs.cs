using Pulumi.Crds.Certmanager.V1;
using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Pulumi.Component.Shared.Certificate
{
    public sealed class CertificateComponentInput : IComponentInput
    {
        public required Namespace Namespace { get; init; }
    }

    public sealed class CertificateComponentOutput : IComponentOutput
    {
        public required ClusterIssuer ClusterIssuer { get; init; }
    }
}