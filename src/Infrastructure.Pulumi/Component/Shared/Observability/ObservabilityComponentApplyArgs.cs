using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Helm.V3;

namespace Infrastructure.Pulumi.Component.Shared.Observability
{
    public sealed class ObservabilityComponentInput : IComponentInput
    {
        public Namespace Namespace { get; init; } = null!;
        
        public Release MinioRelease { get; init; } = null!;
    }

    public sealed class ObservabilityComponentOutput : IComponentOutput
    {
    }
}