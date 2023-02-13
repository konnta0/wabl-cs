using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Component.WebApplication.Resource.Promtail
{
    public sealed class PromtailComponentInput : IComponentInput
    {
        public Namespace Namespace { get; set; }
    }

    public sealed class PromtailComponentOutput : IComponentOutput
    {
    }
}