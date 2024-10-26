using Pulumi.Crds.Certmanager.V1;
using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Pulumi.Component.Shared.ContainerRegistry.Harbor
{
    public sealed class HarborComponentInput : IComponentInput
    {
        public required Namespace Namespace { get; init; }
        public required Issuer Issuer { get; init; }
    }

    public sealed class HarborComponentOutput : IComponentOutput
    {
    }
}