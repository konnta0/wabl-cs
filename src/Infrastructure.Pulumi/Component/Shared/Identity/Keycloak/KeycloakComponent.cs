using System.Collections.Generic;
using System.Linq;
using Pulumi;
using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Networking.V1;
using Pulumi.Kubernetes.Types.Inputs.Apps.V1;
using Pulumi.Kubernetes.Types.Inputs.Core.V1;
using Pulumi.Kubernetes.Types.Inputs.Meta.V1;
using Pulumi.Kubernetes.Types.Inputs.Networking.V1;
using Deployment = Pulumi.Kubernetes.Apps.V1.Deployment;

namespace Infrastructure.Pulumi.Component.Shared.Identity.Keycloak;

public sealed class KeycloakComponent : IComponent<KeycloakComponentInput, KeycloakComponentOutput>
{
    public KeycloakComponentOutput Apply(KeycloakComponentInput input)
    {
        var deployment = new Deployment("keycloak-deployment", new DeploymentArgs
        {
            Metadata = new ObjectMetaArgs
            {
                Name = "keycloak",
                Namespace = input.Namespace.Metadata.Apply(static x => x.Name),
                Labels =
                {
                    { "app", "keycloak" }
                }
            },
            Spec = new DeploymentSpecArgs
            {
                Replicas = 1,
                Selector = new LabelSelectorArgs
                {
                    MatchLabels = new InputMap<string>
                    {
                        { "app", "keycloak" }
                    }
                },
                Template = new PodTemplateSpecArgs
                {
                    Metadata = new ObjectMetaArgs
                    {
                        Labels = new InputMap<string>
                        {
                            { "app", "keycloak" }
                        }
                    },
                    Spec = new PodSpecArgs
                    {
                        Containers = new InputList<ContainerArgs>
                        {
                            new ContainerArgs
                            {
                                Name = "keycloak",
                                Image = "quay.io/keycloak/keycloak:latest",
                                Args = { "start-dev" },
                                Ports =
                                {
                                    new ContainerPortArgs
                                    {
                                        Name = "http",
                                        ContainerPortValue = 8080
                                    }
                                },
                                Env =
                                {
                                    new EnvVarArgs
                                    {
                                        Name = "KEYCLOAK_ADMIN",
                                        Value = "admin"
                                    },
                                    new EnvVarArgs
                                    {
                                        Name = "KEYCLOAK_ADMIN_PASSWORD",
                                        Value = "admin"
                                    },
                                    new EnvVarArgs
                                    {
                                        Name = "KC_PROXY",
                                        Value = "edge"
                                    }
                                },
                                ReadinessProbe = new ProbeArgs
                                {
                                    HttpGet = new HTTPGetActionArgs
                                    {
                                        Path = "/realms/master",
                                        Port = 8080
                                    },
                                    InitialDelaySeconds = 30,
                                    TimeoutSeconds = 5,
                                    PeriodSeconds = 10,
                                    SuccessThreshold = 1,
                                    FailureThreshold = 3
                                }
                            }
                        }
                    }
                }
            }
        });

        var service = new Service("keycloak-service", new ServiceArgs
        {
            Metadata = new ObjectMetaArgs
            {
                Name = "keycloak",
                Namespace = input.Namespace.Metadata.Apply(static x => x.Name),
                Labels =
                {
                    { "app", "keycloak" }
                }
            },
            Spec = new ServiceSpecArgs
            {
                Ports = new InputList<ServicePortArgs>
                {
                    new ServicePortArgs
                    {
                        Name = "http",
                        Port = 80,
                        TargetPort = deployment.Spec.Apply(static x =>
                            x.Template.Spec.Containers[0].Ports[0].ContainerPortValue)
                    }
                },
                Selector = new InputMap<string>
                {
                    { "app", "keycloak" }
                },
                Type = ServiceSpecType.ClusterIP
            }
        });

        var ingress = new Ingress("keycloak-ingress",
            new IngressArgs
            {
                ApiVersion = "networking.k8s.io/v1",
                Metadata = new ObjectMetaArgs
                {
                    Name = "keycloak-ingress",
                    Namespace = input.Namespace.Metadata.Apply(x => x.Name)
                },
                Spec = new IngressSpecArgs
                {
                    IngressClassName = "nginx",
                    Rules = new List<IngressRuleArgs>
                    {
                        new()
                        {
                            Host = "identity.shared.test",
                            Http = new HTTPIngressRuleValueArgs
                            {
                                Paths = new HTTPIngressPathArgs
                                {
                                    Path = "/",
                                    PathType = "Prefix",
                                    Backend = new IngressBackendArgs
                                    {
                                        Service = new IngressServiceBackendArgs
                                        {
                                            Name = service.Metadata.Apply(x => x.Name),
                                            Port = new ServiceBackendPortArgs
                                                { Number = service.Spec.Apply(x => x.Ports.First().Port) }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            });
        return new KeycloakComponentOutput();
    }
}