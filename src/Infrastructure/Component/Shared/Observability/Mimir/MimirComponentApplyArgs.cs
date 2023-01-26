using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Component.Shared.Observability.Mimir
{
    public sealed class MimirComponentInput : IComponentInput
    {
        public Namespace Namespace { get; set; }
    }

    public sealed class MimirComponentOutput : IComponentOutput
    {
    }
}