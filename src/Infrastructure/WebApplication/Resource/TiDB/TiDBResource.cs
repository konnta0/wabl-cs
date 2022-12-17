using System.Collections.Generic;
using Infrastructure.Extension;
using Pulumi;
using Pulumi.Crds.Pingcap.V1Alpha1;
using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Helm.V3;
using Pulumi.Kubernetes.Types.Inputs.Apps.V1;
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
                    StorageClassName = "standard",
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

            // https://github.com/pingcap/tidb-operator/blob/master/charts/tidb-cluster/templates/monitor-deployment.yaml
            var monitorDeployment = new Pulumi.Kubernetes.Apps.V1.Deployment("tidb-monitor-deployment", new DeploymentArgs
            {
                Metadata = new ObjectMetaArgs
                {
                    Name = "tidb-monitor",
                    Namespace = _config.GetWebApplicationConfig().Namespace,
                    Labels = new InputMap<string>
                    {                            
                        {"app.kubernetes.io/name", "tidb-operator"},
                        {"app.kubernetes.io/component", "monitor"}
                    }
                },
                Spec = new DeploymentSpecArgs
                {
                    Replicas = 1,
                    Strategy = new DeploymentStrategyArgs
                    {
                        Type = "Recreate",
                        RollingUpdate = null
                    },
                    Selector = new LabelSelectorArgs
                    {
                        MatchLabels = new InputMap<string>
                        {
                            {"app.kubernetes.io/name", "tidb-operator"},
                            {"app.kubernetes.io/component", "monitor"}
                        }
                    },
                    Template = new PodTemplateSpecArgs
                    {
                        Spec = new PodSpecArgs
                        {
                            InitContainers = new InputList<ContainerArgs>
                            {
                                new ContainerArgs
                                {
                                    Name = "monitor-initializer",
                                    Image = "pingcap/tidb-monitor-initializer:v6.1.0",
                                    ImagePullPolicy = "IfNotPresent",
                                    Env = new InputList<EnvVarArgs>
                                    {
                                        new EnvVarArgs
                                        {
                                            Name = "GF_PROVISIONING_PATH",
                                            Value = "/grafana-dashboard-definitions/tidb" 
                                        },
                                        new EnvVarArgs
                                        {
                                            Name = "GF_DATASOURCE_PATH",
                                            Value = "/etc/grafana/provisioning/datasources"
                                        },
                                        new EnvVarArgs
                                        {
                                            Name = "TIDB_CLUSTER_NAME",
                                            Value = "tidb-cluster"
                                        },
                                        new EnvVarArgs
                                        {
                                            Name = "TIDB_ENABLE_BINLOG",
                                            Value = bool.FalseString.ToLower()
                                        },
                                        new EnvVarArgs
                                        {
                                            Name = "GF_PROVISIONING_PATH",
                                            Value = "/grafana-dashboard-definitions/tidb"
                                        },
                                        new EnvVarArgs
                                        {
                                            Name = "PROM_CONFIG_PATH",
                                            Value = "/prometheus-rules"
                                        },
                                        new EnvVarArgs
                                        {
                                            Name = "PROM_PERSISTENT_DIR",
                                            Value = "/data"
                                        },
                                        new EnvVarArgs
                                        {
                                            Name = "TIDB_VERSION",
                                            Value = "pingcap/tidb:v6.1.0"
                                        },
                                        new EnvVarArgs
                                        {
                                            Name = "GF_K8S_PROMETHEUS_URL",
                                            Value = "http://prometheus-k8s.monitoring.svc:9090"
                                        },
                                        new EnvVarArgs
                                        {
                                            Name = "GF_TIDB_PROMETHEUS_URL",
                                            Value = "http://127.0.0.1:9090"
                                        },
                                        new EnvVarArgs
                                        {
                                            Name = "TIDB_CLUSTER_NAMESPACE",
                                            Value = _config.GetWebApplicationConfig().Namespace
                                        },
                                        new EnvVarArgs
                                        {
                                            Name = "TZ",
                                            Value = "UTC"
                                        }
                                    },
                                    Command = new InputList<string>
                                    {
                                        "/bin/sh",
                                        "-c",
                                        "mkdir -p /data/prometheus /data/grafana",
                                        "chmod 777 /data/prometheus /data/grafana",
                                        "/usr/bin/init.sh"
                                    },
                                    SecurityContext = new SecurityContextArgs
                                    {
                                        RunAsUser = 0
                                    },
                                    VolumeMounts = new InputList<VolumeMountArgs>
                                    {
                                        new VolumeMountArgs
                                        {
                                            MountPath = "/grafana-dashboard-definitions/tidb",
                                            Name = "grafana-dashboard",
                                            ReadOnly = false
                                        },
                                        new VolumeMountArgs
                                        {
                                            MountPath = "/prometheus-rules",
                                            Name = "prometheus-rules",
                                            ReadOnly = false
                                        },
                                        new VolumeMountArgs
                                        {
                                            MountPath = "/data",
                                            Name = "monitor-data",
                                        },
                                        new VolumeMountArgs
                                        {
                                            MountPath = "/etc/grafana/provisioning/datasources",
                                            Name = "datasource",
                                            ReadOnly = false
                                        }
                                    }
                                },
                                new ContainerArgs
                                {
                                    Name = "prometheus",
                                    Image = "prom/prometheus:v2.27.1",
                                    ImagePullPolicy = "IfNotPresent",
                                    Command = new InputList<string>
                                    {
                                        "/bin/prometheus",
                                        "--web.enable-admin-api",
                                        "--web.enable-lifecycle",
                                        "--log.level=info",
                                        "--config.file=/etc/prometheus/prometheus.yml",
                                        "--storage.tsdb.path=/data/prometheus",
                                        "--storage.tsdb.retention.time=1d"
                                    },
                                    Ports = new InputList<ContainerPortArgs>
                                    {
                                        new ContainerPortArgs
                                        {
                                            Name = "prometheus",
                                            ContainerPortValue = 9090,
                                            Protocol = "TCP"
                                        }
                                    },
                                    Env = new InputList<EnvVarArgs>
                                    {
                                        new EnvVarArgs
                                        {
                                            Name = "TZ",
                                            Value = "UTC"
                                        }
                                    },
                                    VolumeMounts = new InputList<VolumeMountArgs>
                                    {
                                        new VolumeMountArgs
                                        {
                                            Name = "prometheus-config",
                                            MountPath = "/etc/prometheus",
                                            ReadOnly = false
                                        },
                                        new VolumeMountArgs
                                        {
                                            Name = "monitor-data",
                                            MountPath = "/data",
                                            ReadOnly = false
                                        }
                                    }
                                },
                                new ContainerArgs
                                {
                                    Name = "reloader",
                                    Image = "pingcap/tidb-monitor-reloader:v1.0.1",
                                    ImagePullPolicy = "IfNotPresent",
                                    Command = new InputList<string>
                                    {
                                        "/bin/reload",
                                        "--root-store-path=/data",
                                        "--sub-store-path=pingcap/tidb:v6.1.0",
                                        "--watch-path=/prometheus-rules/rules",
                                        "--prometheus-url=http://127.0.0.1:9090"
                                    },
                                    Ports = new InputList<ContainerPortArgs>
                                    {
                                        new ContainerPortArgs
                                        {
                                            Name = "reloader",
                                            ContainerPortValue = 9090,
                                            Protocol = "TCP"
                                        }
                                    },
                                    VolumeMounts = new InputList<VolumeMountArgs>
                                    {
                                        new VolumeMountArgs
                                        {
                                            Name = "prometheus-rules",
                                            MountPath = "/prometheus-rules",
                                            ReadOnly = false
                                        },
                                        new VolumeMountArgs
                                        {
                                            Name = "monitor-data",
                                            MountPath = "/data"
                                        }
                                    },
                                    Env = new EnvVarArgs
                                    {
                                        Name = "TZ",
                                        Value = "UTC"
                                    }
                                },
                                new ContainerArgs
                                {
                                    Name = "grafana",
                                    Image = "grafana/grafana:6.1.6",
                                    ImagePullPolicy = "IfNotPresent",
                                    Ports = new InputList<ContainerPortArgs>
                                    {
                                        new ContainerPortArgs
                                        {
                                            Name = "grafana",
                                            ContainerPortValue = 3000,
                                            Protocol = "TCP"
                                        }
                                    },
                                    Env = new InputList<EnvVarArgs>
                                    {
                                        new EnvVarArgs
                                        {
                                            Name = "GF_PATHS_DATA",
                                            Value = "/data/grafana"
                                        },
                                        new EnvVarArgs
                                        {
                                            Name = "GF_SECURITY_ADMIN_USER",
                                            Value = "admin"
                                        },
                                        new EnvVarArgs
                                        {
                                            Name = "GF_SECURITY_ADMIN_PASSWORD",
                                            Value = "admin12345"
                                        },
                                        new EnvVarArgs
                                        {
                                            Name = "GF_AUTH_ANONYMOUS_ENABLED",
                                            Value = bool.TrueString.ToLower()
                                        },
                                        new EnvVarArgs
                                        {
                                            Name = "GF_AUTH_ANONYMOUS_ORG_NAME",
                                            Value = "Main Org."
                                        },
                                        new EnvVarArgs
                                        {
                                            Name = "GF_AUTH_ANONYMOUS_ORG_ROLE",
                                            Value = "Viewer"
                                        },
                                        new EnvVarArgs
                                        {
                                            Name = "TZ",
                                            Value = "UTC"
                                        }
                                    },
                                    VolumeMounts = new InputList<VolumeMountArgs>
                                    {
                                        new VolumeMountArgs
                                        {
                                            Name = "monitor-data",
                                            MountPath = "/data"
                                        },
                                        new VolumeMountArgs
                                        {
                                            Name = "datasource",
                                            MountPath = "/etc/grafana/provisioning/datasources",
                                            ReadOnly = false
                                        },
                                        new VolumeMountArgs
                                        {
                                            Name = "dashboards-provisioning",
                                            MountPath = "/etc/grafana/provisioning/dashboards",
                                            ReadOnly = false
                                        },
                                        new VolumeMountArgs
                                        {
                                            Name = "grafana-dashboard",
                                            MountPath = "/grafana-dashboard-definitions/tidb",
                                            ReadOnly = false
                                        }
                                    }
                                }
                            },
                            Volumes = new InputList<VolumeArgs>
                            {
                                new VolumeArgs
                                {
                                    Name = "monitor-data",
                                    EmptyDir = new EmptyDirVolumeSourceArgs()
                                },
                                new VolumeArgs
                                {
                                    Name = "prometheus-config",
                                    ConfigMap = new ConfigMapVolumeSourceArgs
                                    {
                                        Name = "tidb-cluster-monitor",
                                        Items = new InputList<KeyToPathArgs>
                                        {
                                            new KeyToPathArgs
                                            {
                                                Key = "prometheus-config",
                                                Path = "prometheus.yml"
                                            }
                                        }
                                    }
                                },
                                new VolumeArgs
                                {
                                    Name = "datasource",
                                    EmptyDir = new EmptyDirVolumeSourceArgs()
                                },
                                new VolumeArgs
                                {
                                    Name = "dashboards-provisioning",
                                    ConfigMap = new ConfigMapVolumeSourceArgs
                                    {
                                        Name = "tidb-cluster-monitor",
                                        Items = new InputList<KeyToPathArgs>
                                        {
                                            new KeyToPathArgs
                                            {
                                                Key = "dashboard-config",
                                                Path = "dashboards.yaml"
                                            }
                                        }
                                    }
                                },
                                new VolumeArgs
                                {
                                    Name = "prometheus-rules",
                                    EmptyDir = new EmptyDirVolumeSourceArgs()
                                },
                                new VolumeArgs
                                {
                                    Name = "grafana-dashboard",
                                    EmptyDir = new EmptyDirVolumeSourceArgs()
                                },
                                new VolumeArgs
                                {
                                    Name = "cluster-client-tls",
                                    Secret = new SecretVolumeSourceArgs
                                    {
                                        DefaultMode = 420,
                                        SecretName = "tidb-operator-cluster-client-secret"
                                    }
                                }
                            }
                        }
                    } 
                }
            });

            // var tidbMonitor = new TidbMonitor("tidb-monitor", new TidbMonitorArgs
            // {
            //     ApiVersion = "pingcap.com/v1alpha1",
            //     Spec = new TidbMonitorSpecArgs
            //     {
            //         ExternalLabels = {{"grafana_dashboard", bool.TrueString.ToLower()}},
            //         Clusters = new TidbMonitorSpecClustersArgs
            //         {
            //             Name = "tidb-cluster",
            //             Namespace = _config.GetWebApplicationConfig().Namespace
            //         },
            //         Initializer = new TidbMonitorSpecInitializerArgs
            //         {
            //             BaseImage = "pingcap/tidb-monitor-initializer",
            //             Version = "v6.1.0",
            //             Envs =
            //             {
            //                 ["GF_PROVISIONING_PATH"] = "/grafana-dashboard-definitions/tidb"
            //             }
            //         },
            //         Reloader = new TidbMonitorSpecReloaderArgs
            //         {
            //             BaseImage = "pingcap/tidb-monitor-reloader",
            //             Version = "v1.0.1"
            //         },
            //         Prometheus = new TidbMonitorSpecPrometheusArgs
            //         {
            //             BaseImage = "prom/prometheus",
            //             Version = "v2.27.1",
            //             Service = new TidbMonitorSpecPrometheusServiceArgs
            //             {
            //                 Type = "NodePort"
            //             }
            //         },
            //         PrometheusReloader = new TidbMonitorSpecPrometheusreloaderArgs
            //         {
            //             BaseImage = "quay.io/prometheus-operator/prometheus-config-reloader",
            //             Version = "v0.49.0"
            //         },
            //         Grafana = new TidbMonitorSpecGrafanaArgs
            //         {
            //             BaseImage = "grafana/grafana",
            //             Version = "7.5.11",
            //             Service = new TidbMonitorSpecGrafanaServiceArgs
            //             {
            //                 Type = "NodePort"
            //             },
            //             AdditionalVolumeMounts = new InputList<TidbMonitorSpecGrafanaAdditionalvolumemountsArgs>
            //             {
            //                 new TidbMonitorSpecGrafanaAdditionalvolumemountsArgs
            //                 {
            //                     Name = "grafana-dashboard",
            //                     MountPath = "/grafana-dashboard-definitions/tidb"
            //                 }
            //             }
            //         },
            //         ImagePullPolicy = "IfNotPresent",
            //         AdditionalVolumes = new InputList<TidbMonitorSpecAdditionalvolumesArgs>
            //         {
            //             new TidbMonitorSpecAdditionalvolumesArgs
            //             {
            //                 Name = "grafana-dashboard",
            //                 PersistentVolumeClaim = new TidbMonitorSpecAdditionalvolumesPersistentvolumeclaimArgs
            //                 {
            //                     ClaimName = pvc.Metadata.Apply(x => x.Name)
            //                 }
            //             }
            //         }
            //     },
            //     Metadata = new ObjectMetaArgs
            //     {
            //         Name = "tidb-monitor",
            //         Namespace = _config.GetWebApplicationConfig().Namespace
            //     }
            // });
        }
    }
}