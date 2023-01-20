using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Component.Shared.Observability.Grafana
{
    public sealed class GrafanaComponentInput : IComponentInput
    {
        public Namespace Namespace { get; set; }
    }

    public sealed class GrafanaComponentOutput : IComponentOutput
    {
    }
}