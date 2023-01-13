using Pulumi.Crds.Certmanager.V1;
using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Component.Shared.Certificate
{
    public sealed class CertificateComponentInput : IComponentInput
    {
        public Namespace Namespace { get; set; }
    }

    public sealed class CertificateComponentOutput : IComponentOutput
    {
        public ClusterIssuer ClusterIssuer { get; set; }
    }
}