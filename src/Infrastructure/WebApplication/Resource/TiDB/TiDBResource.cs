using System.Collections.Generic;
using Infrastructure.Extension;
using Pulumi;
using Pulumi.Crds.Pingcap.V1Alpha1;
using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Helm.V3;
using Pulumi.Kubernetes.Types.Inputs.Core.V1;
using Pulumi.Kubernetes.Types.Inputs.Helm.V3;
using Pulumi.Kubernetes.Types.Inputs.Meta.V1;
using Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.WebApplication.Resource.TiDB
{
    public class TiDBResource
    {
        private readonly Config _config;

        public TiDBResource(Config config)
        {
            _config = config;
        }

        public void Apply()
        {
            // https://docs.pingcap.com/tidb-in-kubernetes/v1.0/deploy-tidb-from-kubernetes-minikube#add-helm-repo
            var configFile = new ConfigFile("web-application-tidb-crd", new ConfigFileArgs
            {
                File = "./WebApplication/Resource/TiDB/Yaml/crd.yaml"
            });
            configFile.Ready();

            var tidbOperator = new Release("web-application-tidb-operator", new ReleaseArgs
            {
                Chart = "tidb-operator",
                // helm search repo pingcap/tidb-operator --versions
                // NAME                    CHART VERSION   APP VERSION     DESCRIPTION
                Version = "v1.3.7",
                RepositoryOpts = new RepositoryOptsArgs
                {
                    Repo = "https://charts.pingcap.org"
                },
                CreateNamespace = false,
                Atomic = true,
                Namespace = _config.GetWebApplicationConfig().Namespace
            });

            // https://github.com/pingcap/tidb-operator/blob/master/charts/tidb-cluster/values.yaml
            var values = new Dictionary<string, object>
            {
                ["pd"] = new Dictionary<string, object>
                {
                    ["storageClassName"] = "standard",
                    ["replicas"] = 1
                },
                ["tikv"] = new Dictionary<string, object>
                {
                    ["storageClassName"] = "standard",
                    ["replicas"] = 1
                },
                ["tidb"] = new Dictionary<string, object>
                {
                    ["replicas"] = 1
                },
                ["monitor"] = new InputMap<object>
                {
                    ["create"] = false
                }
            };

            var tidbCluster = new Release("web-application-tidb-cluster", new ReleaseArgs
            {
                Name = "tidb-cluster",
                Chart = "tidb-cluster",
                // helm search repo pingcap/tidb-cluster --versions
                // NAME                    CHART VERSION   APP VERSION     DESCRIPTION
                // pingcap/tidb-cluster    v1.3.8                          A Helm chart for TiDB Cluster
                Version = "v1.3.7",
                RepositoryOpts = new RepositoryOptsArgs
                {
                    Repo = "https://charts.pingcap.org"
                },
                CreateNamespace = false,
                Atomic = true,
                Values = values,
                Namespace = tidbOperator.Namespace.Apply(x => x),
                RecreatePods = true
            });

            var pv = new PersistentVolume("tidb-monitor-grafana-pv", new PersistentVolumeArgs
            {
                Metadata = new ObjectMetaArgs
                {
                    Labels =
                    {
                        ["type"] = "tidb-grafana-dashboard"
                    }
                },
                Spec = new PersistentVolumeSpecArgs
                {
                    AccessModes = "ReadWriteMany",
                    Capacity =
                    {
                        ["storage"] = "300Mi"
                    },
                    VolumeMode = "Filesystem",
                    PersistentVolumeReclaimPolicy = "Retain",
                    StorageClassName = "manual",
                    HostPath = new HostPathVolumeSourceArgs
                    {
                        Path = "/tmp",
                        Type = "Directory"
                    }
                }
            });

            var pvc = new PersistentVolumeClaim("tidb-monitor-grafana-pvc", new PersistentVolumeClaimArgs
            {
                Metadata = new ObjectMetaArgs
                {
                    Namespace = _config.GetWebApplicationConfig().Namespace
                },
                Spec = new PersistentVolumeClaimSpecArgs
                {
                    AccessModes = "ReadWriteMany",
                    VolumeMode = pv.Spec.Apply(x => x.VolumeMode),
                    Resources = new ResourceRequirementsArgs
                    {
                        Requests =
                        {
                            ["storage"] = "200Mi"
                        }
                    },
                    Selector = new LabelSelectorArgs
                    {
                        MatchLabels =
                        {
                            ["type"] = pv.Metadata.Apply(x => x.Labels["type"])
                        }
                    },
                    StorageClassName = pv.Spec.Apply(x => x.StorageClassName)
                }
            });

            var tidbMonitor = new TidbMonitor("tidb-monitor", new TidbMonitorArgs
            {
                ApiVersion = "pingcap.com/v1alpha1",
                Spec = new TidbMonitorSpecArgs
                {
                    ExternalLabels = {{"grafana_dashboard", bool.TrueString.ToLower()}},
                    Clusters = new TidbMonitorSpecClustersArgs
                    {
                        Name = "tidb-cluster",
                        Namespace = _config.GetWebApplicationConfig().Namespace
                    },
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
                        },
                    },
                    ImagePullPolicy = "IfNotPresent" 
                },
                Metadata = new ObjectMetaArgs
                {
                    Name = "tidb-monitor",
                    Namespace = _config.GetWebApplicationConfig().Namespace
                }
            });
        }
    }
}