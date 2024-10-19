using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Pulumi.Component.Shared.Observability.SigNoz
{
    public sealed class SigNozComponentInput : IComponentInput
    {
        public required Namespace Namespace { get; init; }
    }

    public sealed class SigNozComponentOutput : IComponentOutput;
}