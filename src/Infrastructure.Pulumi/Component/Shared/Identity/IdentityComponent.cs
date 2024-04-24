using Infrastructure.Pulumi.Component.Shared.Identity.Keycloak;

namespace Infrastructure.Pulumi.Component.Shared.Identity;

public class IdentityComponent(KeycloakComponent keycloakComponent)
    : IComponent<IdentityComponentInput, IdentityComponentOutput>
{
    public IdentityComponentOutput Apply(IdentityComponentInput input)
    {
        keycloakComponent.Apply(new KeycloakComponentInput
        {
            Namespace = input.Namespace
        });

        return new IdentityComponentOutput();
    }
}