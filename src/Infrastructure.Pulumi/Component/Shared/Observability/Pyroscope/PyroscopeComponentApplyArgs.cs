using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Pulumi.Component.Shared.Observability.Pyroscope
{
    public sealed class PyroscopeComponentInput : IComponentInput
    {
        public required Namespace Namespace { get; set; }
    }

    public sealed class PyroscopeComponentOutput : IComponentOutput
    {
    }
}