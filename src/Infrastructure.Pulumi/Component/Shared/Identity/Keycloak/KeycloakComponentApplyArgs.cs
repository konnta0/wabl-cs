using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Pulumi.Component.Shared.Identity.Keycloak;

public sealed class KeycloakComponentInput : IComponentInput
{
    public Namespace Namespace { get; init; } = null!;
}

public sealed class KeycloakComponentOutput : IComponentOutput
{
}