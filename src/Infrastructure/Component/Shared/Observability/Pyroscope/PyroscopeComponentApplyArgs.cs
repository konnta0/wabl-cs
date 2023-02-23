using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Component.Shared.Observability.Pyroscope
{
    public sealed class PyroscopeComponentInput : IComponentInput
    {
        public Namespace Namespace { get; set; } = null!;
    }

    public sealed class PyroscopeComponentOutput : IComponentOutput
    {
    }
}