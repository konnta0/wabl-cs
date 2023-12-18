using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.Pulumi.Component.WebApplication.OpenTelemetryOperator
{
    public sealed class OpenTelemetryOperatorComponentInput : IComponentInput
    {
        public Namespace Namespace { get; set; } = null!;
    }

    public sealed class OpenTelemetryOperatorComponentOutput : IComponentOutput
    {
        public ConfigFile OpenTelemetryCrd { get; set; } = null!;
    }
}