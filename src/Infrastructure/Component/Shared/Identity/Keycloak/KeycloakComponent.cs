using Pulumi;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.Component.Shared.Identity.Keycloak;

public sealed class KeycloakComponent : IComponent<KeycloakComponentInput, KeycloakComponentOutput>
{
    public KeycloakComponentOutput Apply(KeycloakComponentInput input)
    {
        var configFile = new ConfigFile("keycloak", new ConfigFileArgs
        {
            File =
                "https://github.com/open-telemetry/opentelemetry-operator/releases/download/v0.60.0/opentelemetry-operator.yaml"
        }, new ComponentResourceOptions { DependsOn = input.Namespace });
        return new KeycloakComponentOutput();
    }
}