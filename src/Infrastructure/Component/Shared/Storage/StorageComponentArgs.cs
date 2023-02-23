using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Component.Shared.Storage
{
    public sealed class StorageComponentInput : IComponentInput
    {
        public Namespace Namespace { get; set; } = null!;
    }

    public sealed class StorageComponentOutput : IComponentOutput
    {
    }
}