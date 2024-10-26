using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Pulumi.Component.Shared.Observability.Promtail
{
    public sealed class PromtailComponentInput : IComponentInput
    {
        public required Namespace Namespace { get; set; }
    }

    public sealed class PromtailComponentOutput : IComponentOutput
    {
    }
}