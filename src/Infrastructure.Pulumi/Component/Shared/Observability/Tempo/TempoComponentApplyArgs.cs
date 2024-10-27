using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Helm.V3;

namespace Infrastructure.Pulumi.Component.Shared.Observability.Tempo
{
    public sealed class TempoComponentInput : IComponentInput
    {
        public required Namespace Namespace { get; init; }
        
        public required Release MinIoRelease { get; init; }
    }

    public sealed class TempoComponentOutput : IComponentOutput
    {
    }
}