using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Component.Shared.Storage.Dragonfly
{
    public sealed class DragonflyComponentInput : IComponentInput
    {
        public Namespace Namespace { get; set; }
    }

    public sealed class DragonflyComponentOutput : IComponentOutput
    {
    }
}