using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Pulumi.Component.Shared.Observability.Loki
{
    public sealed class LokiComponentInput : IComponentInput
    {
        public required Namespace Namespace { get; init; }
    }

    public sealed class LokiComponentOutput : IComponentOutput
    {
    }
}