using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Pulumi.Component.Shared.Identity;

public sealed class IdentityComponentInput : IComponentInput
{
    public required Namespace Namespace { get; init; }
}

public sealed class IdentityComponentOutput : IComponentOutput
{
}