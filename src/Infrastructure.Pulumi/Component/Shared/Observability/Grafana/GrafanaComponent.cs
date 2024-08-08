using System.Collections.Generic;
using System.IO;
using Infrastructure.Pulumi.Extension;
using Pulumi;
using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Helm.V3;
using Pulumi.Kubernetes.Networking.V1;
using Pulumi.Kubernetes.Types.Inputs.Core.V1;
using Pulumi.Kubernetes.Types.Inputs.Helm.V3;
using Pulumi.Kubernetes.Types.Inputs.Meta.V1;
using Pulumi.Kubernetes.Types.Inputs.Networking.V1;

namespace Infrastructure.Pulumi.Component.Shared.Observability.Grafana
{
    public class GrafanaComponent(Config config)
        : IComponent<GrafanaComponentInput, GrafanaComponentOutput>
    {
        
        public GrafanaComponentOutput Apply(GrafanaComponentInput input)
        {
            string testDashboardJsonString;
            using (var sr = new StreamReader("Component/Shared/Observability/Grafana/Dashboard/dashboard.json"))
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
                        ["grafana_dashboard"] = bool.TrueString.ToLower()
                    },
                    Namespace = input.Namespace.Metadata.Apply(x => x.Name)
                }
            });

            // ref: https://github.com/grafana/helm-charts/blob/main/charts/grafana/values.yaml
            var grafana = new Release("grafana", new ReleaseArgs
            {
                Name = "grafana",
                Chart = "grafana",
                //  helm search repo grafana/grafana --versions | head -n 5
                Version = "6.59.0",
                RepositoryOpts = new RepositoryOptsArgs
                {
                    Repo = "https://grafana.github.io/helm-charts"
                },
                Atomic = true,
                Values = new Dictionary<string, object>
                {
                    ["adminPassword"] = "grafana12345",
                    ["sidecar"] = new Dictionary<string, object>
                    {
                        ["dashboards"] = new Dictionary<string, object>
                        {
                            ["enabled"] = true,
                            ["label"] = "grafana_dashboard",
                            ["labelValue"] = bool.TrueString.ToLower(),
                            ["searchNamespace"] =
                                string.Join(",", "shared", config.GetWebApplicationConfig().Namespace)
                        }
                    },
                    ["dashboardProviders"] = new Dictionary<string, object>
                    {
                        ["tidb-dashboard.yaml"] = new Dictionary<string, object>
                        {
                            ["apiVersion"] = 1,
                            ["providers"] = new List<object>
                            {
                                new Dictionary<string, object>
                                {
                                    ["folder"] = "",
                                    ["name"] = "0",
                                    ["options"] = new Dictionary<string, object>
                                    {
                                        ["path"] = "/grafana-dashboard-definitions/tidb"
                                    },
                                    ["allowUiUpdates"] = bool.TrueString.ToLower(),
                                    ["orgId"] = 1,
                                    ["type"] = "file"
                                }
                            }
                        }
                    },
                    ["extraVolumeMounts"] = new List<object>
                    {
                        new Dictionary<string, object>
                        {
                            ["name"] = "tidb-grafana-dashboard",
                            ["mountPath"] = "/grafana-dashboard-definitions/tidb"
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
                                    { "name", "Mimir" },
                                    { "type", "prometheus" },
                                    { "uid", "mimir" },
                                    { "orgId", 1 },
                                    { "url", "http://mimir-distributed-query-frontend:8080/prometheus" },
                                    {
                                        "jsonData", new Dictionary<string, object>
                                        {
                                            ["httpHeaderName1"] = "X-Scope-OrgID"
                                        }
                                    },
                                    {
                                        "secureJsonData", new Dictionary<string, object>
                                        {
                                            ["httpHeaderValue1"] = "1"
                                        }
                                    },
                                    { "basicAuth", false },
                                    { "isDefault", true },
                                    { "version", 1 },
                                    { "editable", false }
                                },
                                new Dictionary<string, object>
                                {
                                    { "name", "Tempo" },
                                    { "type", "tempo" },
//                                {"access", "proxy"},
                                    { "orgId", 1 },
                                    { "url", "http://tempo-distributed-query-frontend:3100" },
                                    { "basicAuth", false },
                                    { "isDefault", false },
                                    { "version", 1 },
                                    { "editable", false },
                                    { "apiVersion", 1 },
                                    { "uid", "tempo" },
                                    {
                                        "jsonData", new Dictionary<string, object>
                                        {
                                            ["tracesToLogsV2"] = new InputMap<object>
                                            {
                                                ["datasourceUid"] = "loki",
                                            },
                                            ["tracesToMetrics"] = new InputMap<object>
                                            {
                                                ["datasourceUid"] = "mimir"
                                            },
                                            ["lokiSearch"] = new InputMap<object>
                                            {
                                                ["datasourceUid"] = "loki"
                                            }
                                        }
                                    }
                                },
                                new Dictionary<string, object>
                                {
                                    { "name", "Loki" },
                                    { "type", "loki" },
                                    { "uid", "loki" },
                                    { "orgId", 1 },
                                    { "url", "http://loki-distributed-query-frontend:3100" },
                                    { "basicAuth", false },
                                    { "isDefault", false },
                                    { "version", 1 },
                                    { "editable", false },
                                    {
                                        "jsonData", new Dictionary<string, object>
                                        {
                                            ["derivedFields"] = new List<object>
                                            {
                                                new Dictionary<string, object>
                                                {
                                                    { "datasourceUid", "tempo" },
                                                    { "matcherRegex", "\"TraceID\":\"(\\w+)" },
                                                    { "name", "TraceID" },
                                                    { "url", "$${__value.raw}" }
                                                }
                                            }
                                        }
                                    }
                                },
                                new Dictionary<string, object>
                                {
                                    { "name", "Pyroscope" },
                                    { "type", "grafana-pyroscope-datasource" },
                                    { "uid", "pyroscope" },
                                    { "orgId", 1 },
                                    { "url", "http://pyroscope-querier.shared.svc.cluster.local.:4040/" },
                                    { "basicAuth", false },
                                    { "isDefault", false },
                                    { "version", 1 },
                                    { "editable", true }
                                }
                            }
                        }
                    }
                },
                RecreatePods = true,
                Namespace = input.Namespace.Metadata.Apply(x => x.Name)
            },
            new CustomResourceOptions
            {
                DependsOn = input.Namespace
            });

            var ingress = new Ingress("grafana-ingress", new IngressArgs
            {
                ApiVersion = "networking.k8s.io/v1",
                Metadata = new ObjectMetaArgs
                {
                    Name = "grafana-ingress",
                    Namespace = input.Namespace.Metadata.Apply(x => x.Name)
                },
                Spec = new IngressSpecArgs
                {
                    IngressClassName = "traefik",
                    Rules = new List<IngressRuleArgs>
                    {
                        new()
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
                                            Name = "grafana",
                                            Port = new ServiceBackendPortArgs { Number = 3000 }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            });
            
            return new GrafanaComponentOutput();
        }
    }
}