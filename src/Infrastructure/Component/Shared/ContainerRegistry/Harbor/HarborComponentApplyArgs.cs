using Pulumi.Crds.Certmanager.V1;
using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Component.Shared.ContainerRegistry.Harbor
{
    public sealed class HarborComponentInput : IComponentInput
    {
        public Namespace Namespace { get; set; } = null!;
        public Issuer Issuer { get; set; } = null!;
    }

    public sealed class HarborComponentOutput : IComponentOutput
    {
    }
}