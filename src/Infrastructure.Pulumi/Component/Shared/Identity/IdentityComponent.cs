using Infrastructure.Pulumi.Component.Shared.Identity.Keycloak;

namespace Infrastructure.Pulumi.Component.Shared.Identity;

public class IdentityComponent : IComponent<IdentityComponentInput, IdentityComponentOutput>
{
    private readonly KeycloakComponent _keycloakComponent;

    public IdentityComponent(KeycloakComponent keycloakComponent)
    {
        _keycloakComponent = keycloakComponent;
    }

    public IdentityComponentOutput Apply(IdentityComponentInput input)
    {
        _keycloakComponent.Apply(new KeycloakComponentInput
        {
            Namespace = input.Namespace
        });

        return new IdentityComponentOutput();
    }
}