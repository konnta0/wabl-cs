using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Helm.V3;

namespace Infrastructure.Pulumi.Component.Shared.Storage.MinIo
{
    public sealed class MinIoComponentInput : IComponentInput
    {
        public Namespace Namespace { get; init; } = null!;
    }

    public sealed class MinIoComponentOutput : IComponentOutput
    {
        public Release Release { get; set; } = null!;
    }
}