using System.Collections.Generic;
using System.IO;
using System.Linq;
using Infrastructure.Extension;
using Microsoft.Extensions.Logging;
using Pulumi;
using Pulumi.Crds.Pingcap.V1Alpha1;
using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Helm.V3;
using Pulumi.Kubernetes.Types.Inputs.Core.V1;
using Pulumi.Kubernetes.Types.Inputs.Helm.V3;
using Pulumi.Kubernetes.Types.Inputs.Meta.V1;
using Pulumi.Kubernetes.Types.Inputs.Networking.V1;
using Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1;
using Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1;

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

        public Output<string> Apply()
        {
            // ref: https://github.com/grafana/helm-charts/blob/main/charts/grafana/values.yaml
            var values = new Dictionary<string, object>
            {
                ["adminPassword"] = "grafana12345",
                ["sidecar"] = new Dictionary<string, object>
                {
                    ["dashboards"] = new Dictionary<string, object>
                    {
                        ["enabled"] = true,
                        ["label"] = "grafana_dashboard",
                        ["labelValue"] = "true",
                        ["searchNamespace"] = _config.GetObservabilityConfig().Namespace,
                    }
                },
                ["datasources"] = new Dictionary<string, object>
                {
                    ["datasource.yaml"] = new Dictionary<string, object>
                    {
                        ["apiVersion"] = 1,
                        ["datasources"] = new List<object>
                        {
                            new Dictionary<string, object>
                            {
                                {"name", "Mimir"},
                                {"type", "prometheus"},
                                {"orgId", 1},
                                {"url", "http://mimir-distributed-query-frontend:8080/prometheus"},
                                {"jsonData", new Dictionary<string, object>
                                {
                                    ["httpHeaderName1"] = "X-Scope-OrgID"
                                }},
                                {"secureJsonData", new Dictionary<string, object>
                                {
                                    ["httpHeaderValue1"] = "1"
                                }},
                                {"basicAuth", false},
                                {"isDefault", true},
                                {"version", 1},
                                {"editable", false}
                            },
                            new Dictionary<string, object>
                            {
                                {"name", "Tempo"},
                                {"type", "tempo"},
//                                {"access", "proxy"},
                                {"orgId", 1},
                                {"url", "http://tempo-distributed-query-frontend:3100"},
                                {"basicAuth", false},
                                {"isDefault", false},
                                {"version", 1},
                                {"editable", false},
                                {"apiVersion", 1},
                                {"uid", "tempo"}
                            },
                            new Dictionary<string, object>
                            {
                                {"name", "Loki"},
                                {"type", "loki"},
//                                {"access", "proxy"},
                                {"orgId", 1},
                                {"url", "http://loki-distributed-query-frontend:3100"},
                                {"basicAuth", false},
                                {"isDefault", false},
                                {"version", 1},
                                {"editable", false},
                                {"jsonData", new Dictionary<string, object>
                                {
                                    ["derivedFields"] = new List<object>
                                    {
                                        new Dictionary<string, object>
                                        {
                                            {"datasourceUid", "tempo"},
                                            {"matcherRegex", "\"TraceID\\\\\":\\\\\"(\\w+)"},
                                            {"name", "TraceID"},
                                            {"url", "$${__value.raw}"}
                                        }
                                    }
                                }}
                            }
                        }
                    }
                }
            };

            string testDashboardJsonString;
            using (var sr = new StreamReader("Observability/Resource/Grafana/Dashboard/dashboard.json"))
            {
                testDashboardJsonString = sr.ReadToEnd();
            }
            _ = new ConfigMap("dashboard-test", new ConfigMapArgs
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
                Name = "grafana",
                Chart = "grafana",
                //  helm search repo grafana/grafana --versions | head -n 5
                Version = "6.40.3",
                RepositoryOpts = new RepositoryOptsArgs
                {
                    Repo = "https://grafana.github.io/helm-charts"
                },
                CreateNamespace = true,
                Atomic = true,
                Values = values,
                RecreatePods = true,
                Namespace = _config.GetObservabilityConfig().Namespace
            });

            var tidbInitializer = new TidbMonitor("tidb-monitor", new TidbMonitorArgs
            {
                ApiVersion = "pingcap.com/v1alpha1",
                Spec = new TidbMonitorSpecArgs
                {
                    Clusters = new TidbMonitorSpecClustersArgs
                    {
                        Name = "tidb-cluster",
                        Namespace = _config.GetObservabilityConfig().Namespace
                    },
                    Persistent = true,
                    StorageClassName = "tidb-monitor-storage-class",
                    Storage = "5G",
                    Initializer = new TidbMonitorSpecInitializerArgs
                    {
                        BaseImage = "pingcap/tidb-monitor-initializer",
                        Version = "v6.1.0"
                    },
                    Reloader = new TidbMonitorSpecReloaderArgs
                    {
                        BaseImage = "pingcap/tidb-monitor-reloader",
                        Version = "v1.0.1"
                    },
                    Prometheus = new TidbMonitorSpecPrometheusArgs
                    {
                        BaseImage = "prom/prometheus",
                        Version = "v2.27.1",
                        Service = new TidbMonitorSpecPrometheusServiceArgs
                        {
                            Type = "NodePort"
                        }
                    },
                    PrometheusReloader = new TidbMonitorSpecPrometheusreloaderArgs
                    {
                        BaseImage = "quay.io/prometheus-operator/prometheus-config-reloader",
                        Version = "v0.49.0"
                    },
                    Grafana = new TidbMonitorSpecGrafanaArgs
                    {
                        BaseImage = "grafana/grafana",
                        Version = "7.5.11",
                        Service = new TidbMonitorSpecGrafanaServiceArgs
                        {
                            Type = "NodePort"
                        }
                    },
                    ImagePullPolicy = "IfNotPresent" 
                },
                Metadata = new ObjectMetaArgs
                {
                    Name = "tidb-monitor-initializer",
                    Namespace = _config.GetObservabilityConfig().Namespace
                }
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
            return ingress.Spec.Apply(x => x.Rules.First().Host);
        }
    }
}