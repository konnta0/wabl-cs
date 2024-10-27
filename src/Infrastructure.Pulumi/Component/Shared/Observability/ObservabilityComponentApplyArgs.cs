using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Helm.V3;

namespace Infrastructure.Pulumi.Component.Shared.Observability
{
    public sealed class ObservabilityComponentInput : IComponentInput
    {
        public required Namespace Namespace { get; init; }
        
        public required Release MinioRelease { get; init; }
    }

    public sealed class ObservabilityComponentOutput : IComponentOutput
    {
    }
}