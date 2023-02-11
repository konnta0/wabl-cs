using System.Collections.Generic;
using System.Linq;
using Infrastructure.Extension;
using Pulumi;
using Pulumi.Kubernetes.Helm.V3;
using Pulumi.Kubernetes.Types.Inputs.Helm.V3;
using Pulumi.Kubernetes.Types.Inputs.Meta.V1;
using Pulumi.Kubernetes.Types.Inputs.Networking.V1;

namespace Infrastructure.Component.Shared.Storage.Dragonfly
{
    public class DragonflyComponent : IComponent<DragonflyComponentInput, DragonflyComponentOutput>
    {
        private readonly Config _config;

        public DragonflyComponent(Config config)
        {
            _config = config;
        }

        public DragonflyComponentOutput Apply(DragonflyComponentInput input)
        {
            // https://github.com/dragonflyoss/helm-charts/blob/main/charts/dragonfly/values.yaml
            var values = new Dictionary<string, object>
            {
                ["manager"] = new Dictionary<string, object>
                {
                    ["replicas"] = 1
                },
                ["seedPeer"] = new Dictionary<string, object>
                {
                    ["replicas"] = 2,
                    ["persistence"] = new Dictionary<string, object>
                    {
                        ["size"] = "2Gi"
                    }
                },
                ["scheduler"] = new Dictionary<string, object>
                {
                    ["replicas"] = 2
                }
            };
            var dragonfly = new Release("dragonfly", new ReleaseArgs
            {
                Name = "dragonfly",
                Chart = "dragonfly",
                // helm search repo dragonfly/dragonfly --versions | head -n 5
                // NAME                    CHART VERSION   APP VERSION     DESCRIPTION
                // dragonfly/dragonfly     0.7.1           0.7.1           Dragonfly is an intelligent P2P based image and...
                // dragonfly/dragonfly     0.7.0           0.7.0           Dragonfly is an intelligent P2P based image and...
                // dragonfly/dragonfly     0.6.16          0.6.16          Dragonfly is an intelligent P2P based image and...
                // dragonfly/dragonfly     0.6.15          0.6.15          Dragonfly is an intelligent P2P based image and...
                Version = "0.7.1",
                RepositoryOpts = new RepositoryOptsArgs
                {
                    Repo = "https://dragonflyoss.github.io/helm-charts"
                },
                Values = values,
                Atomic = true,
                Namespace = input.Namespace.Metadata.Apply(x => x.Name)
            });

            var ingress = new Pulumi.Kubernetes.Networking.V1.Ingress("dragonfly-manager-ingress", new IngressArgs
            {
                ApiVersion = "networking.k8s.io/v1",
                Metadata = new ObjectMetaArgs
                {
                    Name = "dragonfly-manager-ingress",
                    Namespace = input.Namespace.Metadata.Apply(x => x.Name)
                },
                Spec = new IngressSpecArgs
                {
                    IngressClassName = "nginx",
                    Rules = new List<IngressRuleArgs>
                    {
                        new IngressRuleArgs
                        {
                            Host = "manager.dragonfly.webapp.test",
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
                                            Name = dragonfly.ResourceNames.Apply(x=> x["Service/v1"].First(serviceName => serviceName.Contains("manager")).Replace(_config.GetWebApplicationConfig().Namespace+"/", "")),
                                            Port = new ServiceBackendPortArgs { Number = 8080 }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            });
            return new DragonflyComponentOutput();
        }
    }
}