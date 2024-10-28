using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.Pulumi.Component.WebApplication.OpenTelemetryOperator
{
    public sealed class OpenTelemetryOperatorComponentInput : IComponentInput
    {
        public required Namespace Namespace { get; init; }
    }

    public sealed class OpenTelemetryOperatorComponentOutput : IComponentOutput
    {
        public required ConfigFile OpenTelemetryCrd { get; init; }
    }
}