using HashiCorp.Cdktf.Providers.Kubernetes.Ingress;

namespace Infrastructure.CDKTF.Construct.Identity.Keycloak;

public class KeycloakIngress : Constructs.Construct
{
    public KeycloakIngress(Constructs.Construct scope, string serviceName, int servicePort) : base(scope,
        "construct-keycloak-ingress")
    {
        _ = new Ingress(scope, "keycloak-ingress", new IngressConfig
        {
            Metadata = new IngressMetadata
            {
                Name = "keycloak-ingress",
                Namespace = "shared",
            },
            Spec = new IngressSpec
            {
                IngressClassName = "treafik",
                Rule = new[]
                {
                    new IngressSpecRule
                    {
                        Host = "identity.shared.test",
                        Http = new IngressSpecRuleHttp
                        {
                            Path = new[]
                            {
                                new IngressSpecRuleHttpPath
                                {
                                    Path = "/",
                                    Backend = new IngressSpecRuleHttpPathBackend
                                    {
                                        ServiceName = serviceName,
                                        ServicePort = servicePort.ToString()
                                    }
                                }
                            }
                        }
                    }
                }
            }
        });
    }
}