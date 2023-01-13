using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Component.Shared.Storage.MinIo
{
    public sealed class MinIoComponentInput : IComponentInput
    {
        public Namespace Namespace { get; set; }
    }

    public sealed class MinIoComponentOutput : IComponentOutput
    {
    }
}