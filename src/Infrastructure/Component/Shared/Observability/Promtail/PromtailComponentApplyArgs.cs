using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Component.Shared.Observability.Promtail
{
    public sealed class PromtailComponentInput : IComponentInput
    {
        public Namespace Namespace { get; set; } = null!;
    }

    public sealed class PromtailComponentOutput : IComponentOutput
    {
    }
}