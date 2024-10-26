using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Pulumi.Component.Shared.Observability.Mimir
{
    public sealed class MimirComponentInput : IComponentInput
    {
        public required Namespace Namespace { get; set; }
    }

    public sealed class MimirComponentOutput : IComponentOutput
    {
    }
}