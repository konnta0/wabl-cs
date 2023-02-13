using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Component.WebApplication.Resource.OpenTelemetryOperator
{
    public sealed class OpenTelemetryOperatorComponentInput : IComponentInput
    {
        public Namespace Namespace { get; set; } = null!;
    }

    public sealed class OpenTelemetryOperatorComponentOutput : IComponentOutput
    {
    }
}