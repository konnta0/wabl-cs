using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Pulumi.Component.Shared.Observability.Grafana
{
    public sealed class GrafanaComponentInput : IComponentInput
    {
        public required Namespace Namespace { get; init; }
    }

    public sealed class GrafanaComponentOutput : IComponentOutput
    {
    }
}