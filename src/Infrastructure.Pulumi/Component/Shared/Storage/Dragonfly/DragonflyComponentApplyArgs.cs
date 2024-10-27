using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Pulumi.Component.Shared.Storage.Dragonfly
{
    public sealed class DragonflyComponentInput : IComponentInput
    {
        public required Namespace Namespace { get; init; }
    }

    public sealed class DragonflyComponentOutput : IComponentOutput
    {
    }
}