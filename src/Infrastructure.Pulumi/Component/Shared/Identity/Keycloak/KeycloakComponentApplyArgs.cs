using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Pulumi.Component.Shared.Identity.Keycloak;

public sealed class KeycloakComponentInput : IComponentInput
{
    public required Namespace Namespace { get; init; }
}

public sealed class KeycloakComponentOutput : IComponentOutput
{
}