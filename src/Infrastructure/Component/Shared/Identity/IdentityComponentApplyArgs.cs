using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Component.Shared.Identity;

public sealed class IdentityComponentInput : IComponentInput
{
    public Namespace Namespace { get; init; } = default!;
}

public sealed class IdentityComponentOutput : IComponentOutput
{
}