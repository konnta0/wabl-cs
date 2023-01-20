using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Component.Shared.Observability.Loki
{
    public sealed class LokiComponentInput : IComponentInput
    {
        public Namespace Namespace { get; set; }
    }

    public sealed class LokiComponentOutput : IComponentOutput
    {
    }
}