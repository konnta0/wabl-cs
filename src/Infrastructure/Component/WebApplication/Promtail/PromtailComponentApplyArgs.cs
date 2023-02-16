using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Component.WebApplication.Promtail
{
    public sealed class PromtailComponentInput : IComponentInput
    {
        public Namespace Namespace { get; set; } = null!;
    }

    public sealed class PromtailComponentOutput : IComponentOutput
    {
    }
}