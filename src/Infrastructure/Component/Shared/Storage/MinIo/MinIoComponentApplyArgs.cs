using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Helm.V3;

namespace Infrastructure.Component.Shared.Storage.MinIo
{
    public sealed class MinIoComponentInput : IComponentInput
    {
        public Namespace Namespace { get; set; }
    }

    public sealed class MinIoComponentOutput : IComponentOutput
    {
        public Release Release { get; set; }
    }
}