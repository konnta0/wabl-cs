using System.Collections.Generic;
using System.IO;
using System.Linq;
using Infrastructure.Extension;
using Pulumi;
using Pulumi.Kubernetes.Autoscaling.V2Beta2;
using Pulumi.Kubernetes.Types.Inputs.Apps.V1;
using Pulumi.Kubernetes.Types.Inputs.Autoscaling.V2Beta2;
using Pulumi.Kubernetes.Types.Inputs.Core.V1;
using Pulumi.Kubernetes.Types.Inputs.Meta.V1;
using Pulumi.Kubernetes.Types.Inputs.Networking.V1;
using Config = Pulumi.Config;
using ContainerArgs = Pulumi.Kubernetes.Types.Inputs.Core.V1.ContainerArgs;
using Secret = Pulumi.Kubernetes.Core.V1.Secret;
using SecretArgs = Pulumi.Kubernetes.Types.Inputs.Core.V1.SecretArgs;
using Service = Pulumi.Kubernetes.Core.V1.Service;
using ServiceArgs = Pulumi.Kubernetes.Types.Inputs.Core.V1.ServiceArgs;

namespace Infrastructure.WebApplication.Resource.Dotnet
{
    public class DotnetApplicationResource
    {
        private readonly Config _config;

        public DotnetApplicationResource(Config config)
        {
            _config = config;
        }

        public void Apply()
        {
            var envInputMap = new InputMap<string>();
            var env = File.ReadAllLines(".env");
            foreach (var e in env)
            {
                var splitEnv = e.Split("=");
                envInputMap.Add(splitEnv.First(), splitEnv.Last());
            }

            var secret = new Secret("web-application-dotnet-application-secret", new SecretArgs
            {
                ApiVersion = "v1",
                Metadata = new ObjectMetaArgs
                {
                    Name = "dotnetapp-env-secret",
                    Namespace = _config.GetWebApplicationConfig().Namespace
                },
                Type = "Opaque",
                StringData = envInputMap
            });

            var deployment = new Pulumi.Kubernetes.Apps.V1.Deployment("web-application-dotnet-application",
                new DeploymentArgs
                {
                    Metadata = new ObjectMetaArgs
                    {
                        Labels =
                        {
                            { "app", "web" }
                        },
                        Namespace = _config.GetWebApplicationConfig().Namespace
                    },
                    Spec = new DeploymentSpecArgs
                    {
                        Replicas = 2,
                        Selector = new LabelSelectorArgs
                        {
                            MatchLabels =
                            {
                                { "app", "web" }
                            }
                        },
                        Template = new PodTemplateSpecArgs
                        {
                            Metadata = new ObjectMetaArgs
                            {
                                Labels =
                                {
                                    { "app", "web" }
                                }
                            },
                            Spec = new PodSpecArgs
                            {
                                Containers =
                                {
                                    new ContainerArgs
                                    {
                                        Image = $"{_config.GetContainerRegistryConfig().Host}/webapp/dotnetapp:latest",
                                        Name = "dotnetapp",
                                        Ports =
                                        {
                                            new ContainerPortArgs
                                            {
                                                ContainerPortValue = 80
                                            }
                                        },
                                        EnvFrom = new EnvFromSourceArgs
                                        {
                                            SecretRef = new SecretEnvSourceArgs
                                            {
                                                Name = secret.Metadata.Apply(x => x.Name)
                                            }
                                        },
                                        Resources = new ResourceRequirementsArgs
                                        {
                                            Requests =
                                            {
                                                {"cpu", "200m"}
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                });
            var service = new Service("web-application-dotnet-service", new ServiceArgs
            {
                Metadata = new ObjectMetaArgs
                {
                    Name = "web-application-dotnet-service",
                    Namespace = _config.GetWebApplicationConfig().Namespace
                },
                Spec = new ServiceSpecArgs
                {
                    Ports = new ServicePortArgs
                    {
                        Port = 8080,
                        Protocol = "TCP",
                        TargetPort = 80
                    },
                    Selector = deployment.Spec.Apply(x => x.Template.Metadata.Labels)
                }
            });

            var ingress = new Pulumi.Kubernetes.Networking.V1.Ingress("web-application-dotnet-ingress",
                new IngressArgs
                {
                    ApiVersion = "networking.k8s.io/v1",
                    Metadata = new ObjectMetaArgs
                    {
                        Name = "dotnetapp-ingress",
                        Namespace = _config.GetWebApplicationConfig().Namespace
                    },
                    Spec = new IngressSpecArgs
                    {
                        IngressClassName = "nginx",
                        Rules = new List<IngressRuleArgs>
                        {
                            new IngressRuleArgs
                            {
                                Host = "dotnet.webapp.test",
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
            var hpa = new HorizontalPodAutoscaler("web-application-dotnet-hpa", new HorizontalPodAutoscalerArgs
            {
                Metadata = new ObjectMetaArgs
                {
                    Namespace = _config.GetWebApplicationConfig().Namespace
                },
                Spec = new HorizontalPodAutoscalerSpecArgs
                {
                    ScaleTargetRef = new CrossVersionObjectReferenceArgs
                    {
                        ApiVersion = "apps/v1",
                        Kind = "Deployment",
                        Name = deployment.Metadata.Apply(x => x.Name)
                    },
                    MinReplicas = 1,
                    MaxReplicas = 10,
                    Metrics = new MetricSpecArgs
                    {
                        Type = "Resource",
                        Resource = new ResourceMetricSourceArgs
                        {
                            Name = "cpu",
                            Target = new MetricTargetArgs
                            {
                                Type = "Utilization",
                                AverageUtilization = 45
                            }
                        }
                    }
                }
            });
        }
    }
}