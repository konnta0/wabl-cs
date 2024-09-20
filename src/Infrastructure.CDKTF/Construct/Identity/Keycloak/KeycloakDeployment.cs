using System.Collections.Generic;
using HashiCorp.Cdktf.Providers.Kubernetes.Deployment;

namespace Infrastructure.CDKTF.Construct.Identity.Keycloak;

internal sealed class KeycloakDeployment : Constructs.Construct
{
    public KeycloakDeployment(Constructs.Construct scope, int containerPort) : base(scope, "construct-keycloak-deployment")
    {
        _ = new Deployment(scope, "keycloak-deployment", new DeploymentConfig
        {
            Metadata = new DeploymentMetadata
            {
                Name = "keycloak",
                Namespace = "shared",
                Labels = new Dictionary<string, string>
                {
                    { "app", "keycloak" }
                }
            },
            Spec = new DeploymentSpec
            {
                Replicas = "1",
                Selector = new DeploymentSpecSelector
                {
                    MatchLabels = new Dictionary<string, string>
                    {
                        { "app", "keycloak" }
                    }
                },
                Template = new DeploymentSpecTemplate
                {
                    Metadata = new DeploymentSpecTemplateMetadata
                    {
                        Labels = new Dictionary<string, string>
                        {
                            { "app", "keycloak" }
                        }
                    },
                    Spec = new DeploymentSpecTemplateSpec
                    {
                        Container = new DeploymentSpecTemplateSpecContainer
                        {
                            Name = "keycloak",
                            Image = "quay.io/keycloak/keycloak:latest",
                            Args = ["start-dev"],
                            Port = new List<DeploymentSpecTemplateSpecContainerPort>
                            {
                                new ()
                                {
                                    ContainerPort = containerPort
                                }
                            },
                            Env = new List<DeploymentSpecTemplateSpecContainerEnv>
                            {
                                new ()
                                {
                                    Name = "KEYCLOAK_ADMIN",
                                    Value = "admin"
                                },
                                new ()
                                {
                                    Name = "KEYCLOAK_ADMIN_PASSWORD",
                                    Value = "admin"
                                },
                                new ()
                                {
                                    Name = "KC_PROXY",
                                    Value = "edge"
                                }
                            },
                            ReadinessProbe = new DeploymentSpecTemplateSpecContainerReadinessProbe
                            {
                                HttpGet = new DeploymentSpecTemplateSpecContainerReadinessProbeHttpGet
                                {
                                    Path = "realms/master",
                                    Port = "8080"
                                },
                                InitialDelaySeconds = 30,
                                TimeoutSeconds = 5,
                                PeriodSeconds = 10,
                                SuccessThreshold = 1,
                                FailureThreshold = 3
                            },
                            Resources = new DeploymentSpecTemplateSpecContainerResources
                            {
                                Requests = new Dictionary<string, string>
                                {
                                    { "memory", "512Mi" },
                                    { "cpu", "200m" }
                                },
                                Limits = new Dictionary<string, string>
                                {
                                    { "memory", "1024Mi" },
                                    { "cpu", "500m" }
                                }
                            }
                        }
                    }
                }
            }
        });
    }
}