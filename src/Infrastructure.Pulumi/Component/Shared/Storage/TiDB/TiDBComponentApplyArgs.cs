using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Pulumi.Component.Shared.Storage.TiDB;

public sealed class TiDBComponentInput : IComponentInput
{
    public required Namespace Namespace { get; init; }
}

public sealed class TiDBComponentOutput : IComponentOutput
{
}