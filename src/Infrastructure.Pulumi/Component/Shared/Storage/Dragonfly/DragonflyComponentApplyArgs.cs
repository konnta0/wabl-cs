using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Pulumi.Component.Shared.Storage.Dragonfly
{
    public sealed class DragonflyComponentInput : IComponentInput
    {
        public Namespace Namespace { get; set; } = null!;
    }

    public sealed class DragonflyComponentOutput : IComponentOutput
    {
    }
}