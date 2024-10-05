using HashiCorp.Cdktf;
using Infrastructure.CDKTF.Construct.Identity.Keycloak;

namespace Infrastructure.CDKTF.StackSet.Shared.Identity;

internal sealed class KeycloakStackSet : TerraformResource
{
    public KeycloakStackSet(Constructs.Construct scope) :
        base(scope, ConstructExtension.ToKebabCase<KeycloakStackSet>(),
            new TerraformResourceConfig
            {
                TerraformResourceType = "stack-set",
            })
    {
        const int containerPort = 8080;
        const string serviceName = "keycloak";
        var deployment = new KeycloakDeployment(scope, containerPort);
        var service = new KeycloakService(scope, serviceName, containerPort);
        var ingress = new KeycloakIngress(scope, serviceName, containerPort);
    }
}