using System.Collections.Generic;
using System.IO;
using System.Linq;
using Infrastructure.Extension;
using Microsoft.Extensions.Logging;
using Pulumi;
using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Helm.V3;
using Pulumi.Kubernetes.Kustomize;
using Pulumi.Kubernetes.Types.Inputs.Core.V1;
using Pulumi.Kubernetes.Types.Inputs.Helm.V3;
using Pulumi.Kubernetes.Types.Inputs.Meta.V1;
using Pulumi.Kubernetes.Types.Inputs.Networking.V1;

namespace Infrastructure.Observability.Resource.Grafana
{
    public class GrafanaResource
    {

        private readonly ILogger<GrafanaResource> _logger;
        private readonly Config _config;

        public GrafanaResource(ILogger<GrafanaResource> logger, Config config)
        {
            _logger = logger;
            _config = config;
        }

        public void Apply()
        {
            string testDashboardJsonString;
            using (var sr = new StreamReader("Observability/Resource/Grafana/Dashboard/dashboard.json"))
            {
                testDashboardJsonString = sr.ReadToEnd();
            }
            _logger.LogInformation(testDashboardJsonString);
            // ref: https://github.com/grafana/helm-charts/blob/main/charts/grafana/values.yaml
            var values = new Dictionary<string, object>
            {
                ["sidecar"] = new Dictionary<string, object>
                {
                    ["dashboards"] = new Dictionary<string, object>
                    {
                        ["enabled"] = true,
                        ["label"] = "grafana_dashboard",
                        ["labelValue"] = "true",
                        ["searchNamespace"] = _config.GetObservabilityConfig().Namespace,
                    }
                }
            };

            var dashboardConfigMap = new ConfigMap("dashboard-test", new ConfigMapArgs
            {
                ApiVersion = "v1",
                Immutable = true,
                Data =
                {
                    ["testdashbaord.json"] = testDashboardJsonString
                },
                Metadata = new ObjectMetaArgs
                {
                    Labels =
                    {
                        ["grafana_dashboard"] = "true"
                    },
                    Namespace = _config.GetObservabilityConfig().Namespace
                }
            });
        
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
                Atomic = true,
                Values = values,
                Namespace = _config.GetObservabilityConfig().Namespace
            });
            
            var ingress = new Pulumi.Kubernetes.Networking.V1.Ingress("grafana-ingress", new IngressArgs
            {
                ApiVersion = "networking.k8s.io/v1",
                Metadata = new ObjectMetaArgs
                {
                    Name = "grafana-ingress",
                    Namespace = _config.GetObservabilityConfig().Namespace
                },
                Spec = new IngressSpecArgs
                {
                    IngressClassName = "nginx",
                    Rules = new List<IngressRuleArgs>
                    {
                        new IngressRuleArgs
                        {
                            Host = "grafana.o11y.test",
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
                                            Name = grafana.ResourceNames.Apply(x=> x["Service/v1"].First().Replace(_config.GetObservabilityConfig().Namespace+"/", "")),
                                            Port = new ServiceBackendPortArgs { Number = 3000 }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            });
            IngressHost = ingress.Spec.Apply(x => x.Rules.First().Host);
        }

        [Output] public Output<string> IngressHost { get; private set; }
    }
}