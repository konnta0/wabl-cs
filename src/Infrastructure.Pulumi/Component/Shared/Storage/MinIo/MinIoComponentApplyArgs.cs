using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Helm.V3;

namespace Infrastructure.Pulumi.Component.Shared.Storage.MinIo
{
    public sealed class MinIoComponentInput : IComponentInput
    {
        public required Namespace Namespace { get; init; }
    }

    public sealed class MinIoComponentOutput : IComponentOutput
    {
        public required Release Release { get; init; }
    }
}