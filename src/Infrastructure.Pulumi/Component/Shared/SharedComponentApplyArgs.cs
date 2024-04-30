using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Pulumi.Component.Shared;

public sealed class SharedComponentInput : IComponentInput
{
}

public sealed class SharedComponentOutput : IComponentOutput
{
    public Namespace Namespace { get; init; } = null!;
}