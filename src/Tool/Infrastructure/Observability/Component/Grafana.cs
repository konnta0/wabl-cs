using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Microsoft.Extensions.Logging;
using Pulumi;
using Pulumi.Kubernetes.Helm.V3;
using Pulumi.Kubernetes.Types.Inputs.Helm.V3;
using Pulumi.Kubernetes.Types.Inputs.Meta.V1;
using Pulumi.Kubernetes.Types.Inputs.Networking.V1;

namespace Infrastructure.Observability.Component
{
    public class Grafana
    {
        private readonly ILogger<Grafana> _logger;

        public Grafana(ILogger<Grafana> logger)
        {
            _logger = logger;
        }

        public void Apply()
        {
            var grafana = new Release("grafana", new ReleaseArgs
            {
                 Chart = "grafana",
                //  helm search repo grafana/grafana --versions | head -n 10                                                                                                                                           1:11:45
                // NAME                            CHART VERSION   APP VERSION     DESCRIPTION
                // grafana/grafana                 6.28.0          8.5.0           The leading tool for querying and visualizing t...
                // grafana/grafana                 6.27.0          8.5.0           The leading tool for querying and visualizing t...
                // grafana/grafana                 6.26.8          8.5.0           The leading tool for querying and visualizing t...
                // grafana/grafana                 6.26.7          8.5.0           The leading tool for querying and visualizing t...
                // grafana/grafana                 6.26.6          8.5.0           The leading tool for querying and visualizing t...
                // grafana/grafana                 6.26.5          8.4.6           The leading tool for querying and visualizing t...
                // grafana/grafana                 6.26.4          8.4.6           The leading tool for querying and visualizing t...
                // grafana/grafana                 6.26.3          8.4.6           The leading tool for querying and visualizing t...
                // grafana/grafana                 6.26.2          8.4.6           The leading tool for querying and visualizing t...
                Version = "6.28.0",
                RepositoryOpts = new RepositoryOptsArgs
                {
                    Repo = "https://grafana.github.io/helm-charts"
                },
                CreateNamespace = true,
                Namespace = Define.Namespace
            });
            Namespace = grafana.Namespace;
            
            var ingress = new Pulumi.Kubernetes.Networking.V1.Ingress("grafana-ingress", new IngressArgs
            {
                ApiVersion = "networking.k8s.io/v1",
                Metadata = new ObjectMetaArgs
                {
                    Name = "grafana-ingress",
                    Namespace = Define.Namespace
                },
                Spec = new IngressSpecArgs
                {
                    IngressClassName = "nginx",
                    Rules = new List<IngressRuleArgs>
                    {
                        new IngressRuleArgs
                        {
                            Host = "o11y.grafana.test",
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
                                            Name = grafana.ResourceNames.Apply(x=> x["Service/v1"].First().Replace(Define.Namespace+"/", "")),
                                            Port = new ServiceBackendPortArgs { Number = 3000 }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            });
        }

        [Output] public Output<string> Namespace { get; private set; }
    }
}