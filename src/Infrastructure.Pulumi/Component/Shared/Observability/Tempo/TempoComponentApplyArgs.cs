using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Helm.V3;

namespace Infrastructure.Pulumi.Component.Shared.Observability.Tempo
{
    public sealed class TempoComponentInput : IComponentInput
    {
        public Namespace Namespace { get; init; } = null!;
        
        public Release MinIoRelease { get; init; } = null!;
    }

    public sealed class TempoComponentOutput : IComponentOutput
    {
    }
}