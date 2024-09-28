using System.Collections.Generic;
using HashiCorp.Cdktf.Providers.Kubernetes.Service;

namespace Infrastructure.CDKTF.Construct.Identity.Keycloak;

internal sealed class KeycloakService : Constructs.Construct
{
    public KeycloakService(Constructs.Construct scope, string serviceName, int servicePort) : base(scope, "construct-keycloak-service")
    {
        _ = new Service(scope, "keycloak-service", new ServiceConfig
        {
            Metadata = new ServiceMetadata
            {
                Name = serviceName,
                Namespace = "shared",
                Labels = new Dictionary<string, string>
                {
                    { "app", "keycloak" }
                }
            },
            Spec = new ServiceSpec
            {
                Selector = new Dictionary<string, string>
                {
                    { "App", "keycloak" }
                },
                Port = new List<ServiceSpecPort>
                {
                    new ()
                    {
                        Port = servicePort,
                        TargetPort = servicePort.ToString()
                    }
                }
            }
        });
    }
}