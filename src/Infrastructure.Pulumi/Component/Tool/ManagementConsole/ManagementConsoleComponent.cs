using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Infrastructure.Pulumi.Extension;
using Microsoft.Extensions.Logging;
using Pulumi;
using Pulumi.Kubernetes.Autoscaling.V2Beta2;
using Pulumi.Kubernetes.Networking.V1;
using Pulumi.Kubernetes.Types.Inputs.Apps.V1;
using Pulumi.Kubernetes.Types.Inputs.Autoscaling.V2Beta2;
using Pulumi.Kubernetes.Types.Inputs.Core.V1;
using Pulumi.Kubernetes.Types.Inputs.Meta.V1;
using Pulumi.Kubernetes.Types.Inputs.Networking.V1;
using Config = Pulumi.Config;
using ContainerArgs = Pulumi.Kubernetes.Types.Inputs.Core.V1.ContainerArgs;
using Deployment = Pulumi.Kubernetes.Apps.V1.Deployment;
using Secret = Pulumi.Kubernetes.Core.V1.Secret;
using SecretArgs = Pulumi.Kubernetes.Types.Inputs.Core.V1.SecretArgs;
using Service = Pulumi.Kubernetes.Core.V1.Service;
using ServiceArgs = Pulumi.Kubernetes.Types.Inputs.Core.V1.ServiceArgs;


namespace Infrastructure.Pulumi.Component.Tool.ManagementConsole;

public class ManagementConsoleComponent(
    ILogger<ManagementConsoleComponent> logger,
    Config config)
    : IComponent<ManagementConsoleComponentInput, ManagementConsoleComponentOutput>
{
    private readonly ILogger<ManagementConsoleComponent> _logger = logger;

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


        var deployment = new Deployment("tool-management-console-deployment",
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
                                    Image = $"{config.GetContainerRegistryConfig().Host}/tool/management-console:latest",
                                    Name = "management-console",
                                    Ports =
                                    {
                                        new[]
                                        {
                                            new ContainerPortArgs
                                            {
                                                ContainerPortValue = 8080 // http
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
                                            Port = 8080 // http
                                        },
                                        InitialDelaySeconds = 3,
                                        PeriodSeconds = 10
                                    }
                                }
                            }
                        }
                    }
                }
            }, new CustomResourceOptions
            {
                CustomTimeouts = new CustomTimeouts
                {
                    Create = TimeSpan.FromMinutes(2),
                    Update = TimeSpan.FromMinutes(2)
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
                Ports =
                [
                    new ServicePortArgs
                    {
                        Name = "http",
                        Port = 80,
                        Protocol = "TCP",
                        TargetPort = 8080
                    }
                ],
                Selector = deployment.Spec.Apply(x => x.Template.Metadata.Labels)
            }
        });

        var ingress = new Ingress("tool-management-console-ingress",
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
                        new()
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
                                                { Number = service.Spec.Apply(x => x.Ports.First().TargetPort.AsT0) }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            });
        // var hpa = new HorizontalPodAutoscaler("tool-management-console-hpa", new HorizontalPodAutoscalerArgs
        // {
        //     Metadata = new ObjectMetaArgs
        //     {
        //         Namespace = input.Namespace.Metadata.Apply(x => x.Name)
        //     },
        //     Spec = new HorizontalPodAutoscalerSpecArgs
        //     {
        //         ScaleTargetRef = new CrossVersionObjectReferenceArgs
        //         {
        //             ApiVersion = "apps/v1",
        //             Kind = "Deployment",
        //             Name = deployment.Metadata.Apply(x => x.Name)
        //         },
        //         MinReplicas = 1,
        //         MaxReplicas = 10,
        //         Metrics = new MetricSpecArgs
        //         {
        //             Type = "Resource",
        //             Resource = new ResourceMetricSourceArgs
        //             {
        //                 Name = "cpu",
        //                 Target = new MetricTargetArgs
        //                 {
        //                     Type = "Utilization",
        //                     AverageUtilization = 45
        //                 }
        //             }
        //         }
        //     }
        //});
        return new ManagementConsoleComponentOutput();
    }
}