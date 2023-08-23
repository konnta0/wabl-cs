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
using Pulumi.Kubernetes.Types.Inputs.Opentelemetry.V1Alpha1;
using Config = Pulumi.Config;
using ContainerArgs = Pulumi.Kubernetes.Types.Inputs.Core.V1.ContainerArgs;
using Secret = Pulumi.Kubernetes.Core.V1.Secret;
using SecretArgs = Pulumi.Kubernetes.Types.Inputs.Core.V1.SecretArgs;
using Service = Pulumi.Kubernetes.Core.V1.Service;
using ServiceArgs = Pulumi.Kubernetes.Types.Inputs.Core.V1.ServiceArgs;

namespace Infrastructure.Component.WebApplication.WebApi
{
    public class WebApiComponent : IComponent<WebApiComponentInput, WebApiComponentOutput>
    {
        private readonly Config _config;

        public WebApiComponent(Config config)
        {
            _config = config;
        }

        public WebApiComponentOutput Apply(WebApiComponentInput input)
        {
            var envInputMap = new InputMap<string>();
            var env = File.ReadAllLines(".env");
            foreach (var e in env)
            {
                var splitEnv = e.Split("=");
                envInputMap.Add(splitEnv.First(), splitEnv.Last());
            }

            var secret = new Secret("web-application-web-api-secret", new SecretArgs
            {
                ApiVersion = "v1",
                Metadata = new ObjectMetaArgs
                {
                    Name = "web-api-env-secret",
                    Namespace = input.Namespace.Metadata.Apply(x => x.Name)
                },
                Type = "Opaque",
                StringData = envInputMap
            });

            string openTelemetryCollectorConfigYaml;
            using (var sr = new StreamReader("Component/WebApplication/Dotnet/Yaml/OpentelemetryCollector/config.yaml"))
            {
                openTelemetryCollectorConfigYaml = sr.ReadToEnd();
            }

            var sidecar = new Pulumi.Crds.Opentelemetry.V1Alpha1.OpenTelemetryCollector("opentelemetry-collector",
                new OpenTelemetryCollectorArgs
                {
                    Metadata = new ObjectMetaArgs
                    {
                        Name = "opentelemetry-collector",
                        Namespace = input.Namespace.Metadata.Apply(x => x.Name)
                    },
                    Spec = new OpenTelemetryCollectorSpecArgs
                    {
                        Mode = "sidecar",
                        Config = openTelemetryCollectorConfigYaml
                    }
                }, new CustomResourceOptions { DependsOn = { input.OpenTelemetryCrd } });

            var instrumentation = new Pulumi.Crds.Opentelemetry.V1Alpha1.Instrumentation(
                "opentelemetry-instrumentation", new InstrumentationArgs
                {
                    Metadata = new ObjectMetaArgs
                    {
                        Name = "opentelemetry-instrumentation",
                        Namespace = input.Namespace.Metadata.Apply(x => x.Name)
                    },
                    Spec = new InstrumentationSpecArgs
                    {
                        Exporter = new InstrumentationSpecExporterArgs
                        {
                            Endpoint = "http://otel-collector:4317"
                        },
                        Propagators = new InputList<string>
                        {
                            "tracecontext",
                            "baggage",
                            "b3"
                        },
                        Sampler = new InstrumentationSpecSamplerArgs
                        {
                            Type = "parentbased_traceidratio",
                            Argument = "0.25"
                        }
                    }
                }, new CustomResourceOptions { DependsOn = { input.OpenTelemetryCrd } });

            var deployment = new Pulumi.Kubernetes.Apps.V1.Deployment("web-application-web-api-deployment",
                new DeploymentArgs
                {
                    Metadata = new ObjectMetaArgs
                    {
                        Name = "web-api",
                        Labels =
                        {
                            { "app", "web" }
                        },
                        Namespace = input.Namespace.Metadata.Apply(x => x.Name)
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
                                        Image = $"{_config.GetContainerRegistryConfig().Host}/webapp/web-api:latest",
                                        Name = "web-api",
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
                                                { "cpu", "200m" }
                                            }
                                        },
                                        LivenessProbe = new ProbeArgs
                                        {
                                            HttpGet = new HTTPGetActionArgs
                                            {
                                                Path = "healthz",
                                                Port = 80
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
            var service = new Service("web-application-web-api-service", new ServiceArgs
            {
                Metadata = new ObjectMetaArgs
                {
                    Name = "web-application-web-api-service",
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

            var ingress = new Pulumi.Kubernetes.Networking.V1.Ingress("web-application-wen-api-ingress",
                new IngressArgs
                {
                    ApiVersion = "networking.k8s.io/v1",
                    Metadata = new ObjectMetaArgs
                    {
                        Name = "web-api-ingress",
                        Namespace = input.Namespace.Metadata.Apply(x => x.Name)
                    },
                    Spec = new IngressSpecArgs
                    {
                        IngressClassName = "nginx",
                        Rules = new List<IngressRuleArgs>
                        {
                            new IngressRuleArgs
                            {
                                Host = "api.webapp.test",
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
            var hpa = new HorizontalPodAutoscaler("web-application-web-api-hpa", new HorizontalPodAutoscalerArgs
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

            return new WebApiComponentOutput();
        }
    }
}