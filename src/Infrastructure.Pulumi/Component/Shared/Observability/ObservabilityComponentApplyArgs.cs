using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Pulumi.Component.Shared.Observability
{
    public sealed class ObservabilityComponentInput : IComponentInput
    {
        public Namespace Namespace { get; set; } = null!;
    }

    public sealed class ObservabilityComponentOutput : IComponentOutput
    {
    }
}