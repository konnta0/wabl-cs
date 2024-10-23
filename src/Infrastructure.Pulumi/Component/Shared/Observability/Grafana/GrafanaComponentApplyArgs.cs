using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Pulumi.Component.Shared.Observability.Grafana
{
    public sealed class GrafanaComponentInput : IComponentInput
    {
        public required Namespace Namespace { get; set; }
    }

    public sealed class GrafanaComponentOutput : IComponentOutput
    {
    }
}