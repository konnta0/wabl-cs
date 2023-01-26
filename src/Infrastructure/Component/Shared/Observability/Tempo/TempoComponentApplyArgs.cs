using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Component.Shared.Observability.Tempo
{
    public sealed class TempoComponentInput : IComponentInput
    {
        public Namespace Namespace { get; set; }
    }

    public sealed class TempoComponentOutput : IComponentOutput
    {
    }
}