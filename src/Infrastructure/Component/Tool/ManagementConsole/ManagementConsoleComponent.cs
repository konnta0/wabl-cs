using System.Collections.Generic;
using System.IO;
using System.Linq;
using Infrastructure.Extension;
using Microsoft.Extensions.Logging;
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


namespace Infrastructure.Component.Tool.ManagementConsole;

public class ManagementConsoleComponent : IComponent<ManagementConsoleComponentInput, ManagementConsoleComponentOutput>
{
    private readonly ILogger<ManagementConsoleComponent> _logger;
    private readonly Config _config;

    public ManagementConsoleComponent(
        ILogger<ManagementConsoleComponent> logger,
        Config config)
    {
        _logger = logger;
        _config = config;
    }

    public ManagementConsoleComponentOutput Apply(ManagementConsoleComponentInput input)
    {
        var envInputMap = new InputMap<string>();
        var env = File.ReadAllLines(".env");
        foreach (var e in env)
        {
            var splitEnv = e.Split("=");
            envInputMap.Add(splitEnv.First(), splitEnv.Last());
        }

        var secret = new Secret("tool-management-console-secret", new SecretArgs
        {
            ApiVersion = "v1",
            Metadata = new ObjectMetaArgs
            {
                Name = "management-console-env-secret",
                Namespace = input.Namespace.Metadata.Apply(x => x.Name)
            },
            Type = "Opaque",
            StringData = envInputMap
        });


        var deployment = new Pulumi.Kubernetes.Apps.V1.Deployment("tool-management-console-deployment",
            new DeploymentArgs
            {
                Metadata = new ObjectMetaArgs
                {
                    Name = "management-console",
                    Labels =
                    {
                        { "app", "management-console" }
                    },
                    Namespace = input.Namespace.Metadata.Apply(x => x.Name)
                },
                Spec = new DeploymentSpecArgs
                {
                    Replicas = 1,
                    Selector = new LabelSelectorArgs
                    {
                        MatchLabels =
                        {
                            { "app", "management-console" }
                        }
                    },
                    Template = new PodTemplateSpecArgs
                    {
                        Metadata = new ObjectMetaArgs
                        {
                            Labels =
                            {
                                { "app", "management-console" }
                            },
                            Annotations =
                            {
                                { "sidecar.opentelemetry.io/inject", bool.TrueString },
                                { "instrumentation.opentelemetry.io/inject-dotnet", bool.FalseString }
                            }
                        },
                        Spec = new PodSpecArgs
                        {
                            Containers =
                            {
                                new ContainerArgs
                                {
                                    Image = $"{_config.GetContainerRegistryConfig().Host}/tool/management-console:latest",
                                    Name = "management-console",
                                    Ports =
                                    {
                                        new[]
                                        {
                                            new ContainerPortArgs
                                            {
                                                ContainerPortValue = 80 // http
                                            }
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
                                            { "cpu", "200m" }
                                        }
                                    },
                                    LivenessProbe = new ProbeArgs
                                    {
                                        HttpGet = new HTTPGetActionArgs
                                        {
                                            Path = "healthz",
                                            Port = 80 // http
                                        },
                                        InitialDelaySeconds = 3,
                                        PeriodSeconds = 10
                                    }
                                }
                            }
                        }
                    }
                }
            });
        var service = new Service("tool-management-console-service", new ServiceArgs
        {
            Metadata = new ObjectMetaArgs
            {
                Name = "tool-management-console-service",
                Namespace = input.Namespace.Metadata.Apply(x => x.Name)
            },
            Spec = new ServiceSpecArgs
            {
                Ports = new InputList<ServicePortArgs>
                {
                    new ServicePortArgs
                    {
                        Name = "http",
                        Port = 8080,
                        Protocol = "TCP",
                        TargetPort = 80
                    }
                },
                Selector = deployment.Spec.Apply(x => x.Template.Metadata.Labels)
            }
        });

        var ingress = new Pulumi.Kubernetes.Networking.V1.Ingress("tool-management-console-ingress",
            new IngressArgs
            {
                ApiVersion = "networking.k8s.io/v1",
                Metadata = new ObjectMetaArgs
                {
                    Name = "management-console-ingress",
                    Namespace = input.Namespace.Metadata.Apply(x => x.Name)
                },
                Spec = new IngressSpecArgs
                {
                    IngressClassName = "nginx",
                    Rules = new List<IngressRuleArgs>
                    {
                        new IngressRuleArgs
                        {
                            Host = "management-console.tool.test",
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
        var hpa = new HorizontalPodAutoscaler("tool-management-console-hpa", new HorizontalPodAutoscalerArgs
        {
            Metadata = new ObjectMetaArgs
            {
                Namespace = input.Namespace.Metadata.Apply(x => x.Name)
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
        return new ManagementConsoleComponentOutput();
    }
}