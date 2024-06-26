using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Pulumi.Component.Shared.Storage.TiDB;

public sealed class TiDBComponentInput : IComponentInput
{
    public Namespace Namespace { get; init; } = null!;
}

public sealed class TiDBComponentOutput : IComponentOutput
{
}