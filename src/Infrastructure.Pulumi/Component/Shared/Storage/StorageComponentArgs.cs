using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Helm.V3;

namespace Infrastructure.Pulumi.Component.Shared.Storage;

public sealed class StorageComponentInput : IComponentInput
{
    public Namespace Namespace { get; init; } = null!;
}

public sealed class StorageComponentOutput : IComponentOutput
{
    public Release MinIoRelease { get; set; } = null!;
}