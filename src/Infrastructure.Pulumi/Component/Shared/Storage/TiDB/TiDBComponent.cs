using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Infrastructure.Pulumi.Extension;
using Pulumi;
using Pulumi.Crds.Pingcap.V1Alpha1;
using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Helm.V3;
using Pulumi.Kubernetes.Rbac.V1;
using Pulumi.Kubernetes.Types.Inputs.Apps.V1;
using Pulumi.Kubernetes.Types.Inputs.Core.V1;
using Pulumi.Kubernetes.Types.Inputs.Helm.V3;
using Pulumi.Kubernetes.Types.Inputs.Meta.V1;
using Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1;
using Pulumi.Kubernetes.Types.Inputs.Rbac.V1;
using Pulumi.Kubernetes.Yaml;
using Deployment = Pulumi.Kubernetes.Apps.V1.Deployment;

namespace Infrastructure.Pulumi.Component.Shared.Storage.TiDB
{
    public class TiDBComponent : IComponent<TiDBComponentInput, TiDBComponentOutput>
    {
        private readonly Config _config;

        public TiDBComponent(Config config)
        {
            _config = config;
        }

        public TiDBComponentOutput Apply(TiDBComponentInput input)
        {
            // https://docs.pingcap.com/tidb-in-kubernetes/v1.0/deploy-tidb-from-kubernetes-minikube#add-helm-repo
            var configFile = new ConfigFile("tidb-crd", new ConfigFileArgs
            {
                File = "./Component/Shared/Storage/TiDB/Yaml/crd.yaml"
            });
            configFile.Ready();

            var tidbOperatorValues = new Dictionary<string, object>
            {
                ["scheduler"] = new Dictionary<string, object>
                {
                    // see: https://github.com/pingcap/tidb-operator/issues/5355#issuecomment-1782483397
                    ["create"] = false
                }
            };
            // https://github.com/pingcap/tidb-operator/blob/v1.5.1/charts/tidb-operator/values.yaml
            var tidbOperator = new Release("tidb-operator", new ReleaseArgs
            {
                Chart = "tidb-operator",
                // helm search repo pingcap/tidb-operator --versions
                Version = "v1.5.1",
                RepositoryOpts = new RepositoryOptsArgs
                {
                    Repo = "https://charts.pingcap.org"
                },
                Atomic = true,
                Values = tidbOperatorValues,
                Namespace = input.Namespace.Metadata.Apply(x => x.Name)
            }, new CustomResourceOptions { DependsOn = { configFile } });

            // var tikvPVC = new PersistentVolumeClaim("tikv-pvc", new PersistentVolumeClaimArgs
            // {
            //     Metadata = new ObjectMetaArgs
            //     {
            //         Namespace = input.Namespace.Metadata.Apply(x => x.Name),
            //         Name = "tikv-pvc",
            //     },
            //     Spec = new PersistentVolumeClaimSpecArgs
            //     {
            //         AccessModes = "ReadWriteOnce",
            //         VolumeMode = "Filesystem",
            //         Resources = new ResourceRequirementsArgs
            //         {
            //             Requests =
            //             {
            //                 ["storage"] = "3Gi"
            //             }
            //         },
            //         StorageClassName = "microk8s-hostpath"
            //     }
            // }, new CustomResourceOptions { DependsOn = { tidbOperator } });
            //
            // var pdPVC = new PersistentVolumeClaim("pd-pvc", new PersistentVolumeClaimArgs
            // {
            //     Metadata = new ObjectMetaArgs
            //     {
            //         Namespace = input.Namespace.Metadata.Apply(x => x.Name),
            //         Name = "pd-pvc",
            //     },
            //     Spec = new PersistentVolumeClaimSpecArgs
            //     {
            //         AccessModes = "ReadWriteOnce",
            //         VolumeMode = "Filesystem",
            //         Resources = new ResourceRequirementsArgs
            //         {
            //             Requests =
            //             {
            //                 ["storage"] = "3Gi"
            //             }
            //         },
            //         StorageClassName = "microk8s-hostpath"
            //     }
            // }, new CustomResourceOptions { DependsOn = { tidbOperator } });

            var pdPVC = new PersistentVolumeClaim("pd-pvc", new PersistentVolumeClaimArgs
            {
                Metadata = new ObjectMetaArgs
                {
                    Namespace = input.Namespace.Metadata.Apply(x => x.Name),
                    Name = "pd-pvc",
                },
                Spec = new PersistentVolumeClaimSpecArgs
                {
                    AccessModes = "ReadWriteOnce",
                    VolumeMode = "Filesystem",
                    Resources = new ResourceRequirementsArgs
                    {
                        Requests =
                        {
                            ["storage"] = "3Gi"
                        }
                    },
                    StorageClassName = "microk8s-hostpath"
                }
            }, new CustomResourceOptions { DependsOn = { tidbOperator } });
            var cluster = new TidbCluster("tidb-cluster", new TidbClusterArgs
            {
                Spec = new TidbClusterSpecArgs
                {
                    
                    Pd = new TidbClusterSpecPdArgs
                    {
                        StorageClassName = pdPVC.Spec.Apply(x => x.StorageClassName),
                        Replicas = 1
                    },
                    Tikv = new TidbClusterSpecTikvArgs
                    {
                        StorageClassName = tikvPVC.Spec.Apply(x => x.StorageClassName),
                        Replicas = 2,
                        Requests = new InputMap<Union<int, string>>
                        {
                            ["storage"] = Union<int, string>.FromT1("3Gi")
                        }
                    },
                    Tidb = new TidbClusterSpecTidbArgs
                    {
                        Replicas = 2,
                        Requests = new InputMap<Union<int, string>>
                        {
                            ["storage"] = Union<int, string>.FromT1("3Gi")
                        }
                    }
                }
            });
            
            return new TiDBComponentOutput();

            // https://github.com/pingcap/tidb-operator/blob/master/charts/tidb-cluster/values.yaml
            var values = new Dictionary<string, object>
            {
                ["rbac"] = new Dictionary<string, object>
                {
                    ["clusterName"] = "tidb-cluster"
                },
                ["pd"] = new Dictionary<string, object>
                {
                    ["storageClassName"] = "standard",
                    ["replicas"] = 1
                },
                ["tikv"] = new Dictionary<string, object>
                {
                    ["storageClassName"] = "standard",
                    ["replicas"] = 2,
                    ["resources"] = new InputMap<object>
                    {
                        ["requests"] = new InputMap<object>
                        {
                            ["storage"] = "3Gi"
                        }
                    }
                },
                ["tidb"] = new Dictionary<string, object>
                {
                    ["replicas"] = 2,
                    ["resources"] = new InputMap<object>
                    {
                        ["requests"] = new InputMap<object>
                        {
                            ["storage"] = "3Gi"
                        }
                    }
                },
                ["monitor"] = new InputMap<object>
                {
                    ["create"] = false
                }
            };

            var tidbCluster = new Release("tidb-cluster", new ReleaseArgs
            {
                Name = "tidb-cluster",
                Chart = "tidb-cluster",
                // helm search repo pingcap/tidb-cluster --versions
                // NAME                    CHART VERSION   APP VERSION     DESCRIPTION
                // pingcap/tidb-cluster    v1.3.8                          A Helm chart for TiDB Cluster
                Version = "v1.3.9",
                RepositoryOpts = new RepositoryOptsArgs
                {
                    Repo = "https://charts.pingcap.org"
                },
                CreateNamespace = false,
                Atomic = true,
                Values = values,
                Namespace = tidbOperator.Namespace.Apply(x => x),
                RecreatePods = true
            }, new CustomResourceOptions { DependsOn = { configFile } });

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
            }, new CustomResourceOptions { DeletedWith = tidbCluster, DependsOn = { tidbCluster } });
            
            
            var serviceAccount = new ServiceAccount("tidb-monitor-service-account", new ServiceAccountArgs
            {
                Metadata = new ObjectMetaArgs
                {
                    Namespace = input.Namespace.Metadata.Apply(x => x.Name),
                    Name = "tidb-cluster-monitor",
                    Labels = new InputMap<string>
                    {
                        { "app.kubernetes.io/name", "tidb-cluster" },
                        { "app.kubernetes.io/instance", "tidb-cluster" },
                        { "app.kubernetes.io/component", "monitor" }
                    }
                }
            }, new CustomResourceOptions { DeletedWith = tidbCluster, DependsOn = { tidbCluster } });
            
            var role = new Role("tidb-monitor-role", new RoleArgs
            {
                Metadata = new ObjectMetaArgs
                {
                    Namespace = input.Namespace.Metadata.Apply(x => x.Name),
                    Name = "tidb-cluster-monitor",
                    Labels = new InputMap<string>
                    {
                        { "app.kubernetes.io/name", "tidb-cluster" },
                        { "app.kubernetes.io/instance", "tidb-cluster" },
                        { "app.kubernetes.io/component", "monitor" }
                    }
                },
                Rules = new InputList<PolicyRuleArgs>
                {
                    new PolicyRuleArgs
                    {
                        ApiGroups = new InputList<string>
                        {
                            string.Empty
                        },
                        Resources = new InputList<string>
                        {
                            "pods"
                        },
                        Verbs = new InputList<string>
                        {
                            "get",
                            "list",
                            "watch"
                        }
                    }
                }
            });
            
            var roleBinding = new RoleBinding("tidb-monitor-role-binding", new RoleBindingArgs
            {
                Metadata = new ObjectMetaArgs
                {
                    Namespace = input.Namespace.Metadata.Apply(x => x.Name),
                    Name = "tidb-cluster-monitor",
                    Labels = new InputMap<string>
                    {
                        { "app.kubernetes.io/name", "tidb-cluster" },
                        { "app.kubernetes.io/instance", "tidb-cluster" },
                        { "app.kubernetes.io/component", "monitor" }
                    }
                },
                Subjects = new InputList<SubjectArgs>
                {
                    new SubjectArgs
                    {
                        Kind = nameof(ServiceAccount),
                        Name = serviceAccount.Metadata.Apply(x => x.Name)
                    }
                },
                RoleRef = new RoleRefArgs
                {
                    Kind = nameof(Role),
                    Name = role.Metadata.Apply(x => x.Name),
                    ApiGroup = "rbac.authorization.k8s.io"
                }
            }, new CustomResourceOptions { DeletedWith = tidbCluster, DependsOn = { tidbCluster } });
            
            
            var pvc = new PersistentVolumeClaim("tidb-monitor-grafana-pvc", new PersistentVolumeClaimArgs
            {
                Metadata = new ObjectMetaArgs
                {
                    Namespace = input.Namespace.Metadata.Apply(x => x.Name)
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
            }, new CustomResourceOptions { DeletedWith = tidbCluster, DependsOn = { tidbCluster } });
            
            var dashboardConfig = new Dictionary<string, object>
            {
                ["apiVersion"] = 1,
                ["providers"] = new List<object>
                {
                    new Dictionary<string, object>
                    {
                        ["folder"] = "",
                        ["name"] = 0,
                        ["options"] = new Dictionary<string, object>
                        {
                            ["path"] = "/grafana-dashboard-definitions/tidb"
                        },
                        ["orgId"] = 1,
                        ["type"] = "file"
                    }
                }
            };
            
            string prometheusConfigYaml;
            using (var sr = new StreamReader("./Component/Shared/Storage/TiDB/Yaml/prometheus.yaml"))
            {
                prometheusConfigYaml = sr.ReadToEnd();
            }
            
            var monitorConfigMap = new ConfigMap("tidb-monitor-configmap", new ConfigMapArgs
            {
                Metadata = new ObjectMetaArgs
                {
                    Name = "tidb-monitor-configmap",
                    Namespace = input.Namespace.Metadata.Apply(x => x.Name),
                    Labels = new InputMap<string>
                    {
                        { "app.kubernetes.io/name", "tidb-cluster" },
                        { "app.kubernetes.io/instance", "tidb-cluster" },
                        { "app.kubernetes.io/component", "monitor" }
                    }
                },
                Data = new InputMap<string>
                {
                    { "prometheus-config", prometheusConfigYaml },
                    { "dashboard-config", JsonSerializer.Serialize(dashboardConfig) }
                }
            }, new CustomResourceOptions { DeletedWith = tidbCluster, DependsOn = { tidbCluster }});
            
            // https://github.com/pingcap/tidb-operator/blob/master/charts/tidb-cluster/templates/monitor-deployment.yaml
            var monitorDeployment = new Deployment("tidb-monitor-deployment",
                new DeploymentArgs
                {
                    Metadata = new ObjectMetaArgs
                    {
                        Name = "tidb-monitor",
                        Namespace = input.Namespace.Metadata.Apply(x => x.Name),
                        Labels = new InputMap<string>
                        {
                            { "app.kubernetes.io/name", "tidb-cluster" },
                            { "app.kubernetes.io/instance", "tidb-cluster" },
                            { "app.kubernetes.io/component", "monitor" }
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
                                { "app.kubernetes.io/name", "tidb-cluster" },
                                { "app.kubernetes.io/instance", "tidb-cluster" },
                                { "app.kubernetes.io/component", "monitor" }
                            }
                        },
                        Template = new PodTemplateSpecArgs
                        {
                            Metadata = new ObjectMetaArgs
                            {
                                Labels = new InputMap<string>
                                {
                                    { "app.kubernetes.io/name", "tidb-cluster" },
                                    { "app.kubernetes.io/instance", "tidb-cluster" },
                                    { "app.kubernetes.io/component", "monitor" }
                                }
                            },
                            Spec = new PodSpecArgs
                            {
                                ServiceAccount = serviceAccount.Metadata.Apply(x => x.Name),
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
                                                Value = "http://prometheus-k8s.webapp.svc:9090"
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
                                            "mkdir -p /data/prometheus /data/grafana\n" +
                                            "chmod 777 /data/prometheus /data/grafana\n" +
                                            "/usr/bin/init.sh\n"
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
                                                Name = "monitor-data"
                                            },
                                            new VolumeMountArgs
                                            {
                                                MountPath = "/etc/grafana/provisioning/datasources",
                                                Name = "datasource",
                                                ReadOnly = false
                                            }
                                        }
                                    }
                                },
                                Containers = new InputList<ContainerArgs>
                                {
                                    new ContainerArgs
                                    {
                                        Name = "prometheus",
                                        Image = "prom/prometheus:v2.18.1",
                                        ImagePullPolicy = "IfNotPresent",
                                        Command = new InputList<string>
                                        {
                                            "/bin/prometheus",
                                            "--web.enable-admin-api",
                                            "--web.enable-lifecycle",
                                            "--log.level=info",
                                            "--config.file=/etc/prometheus/prometheus.yml",
                                            "--storage.tsdb.path=/data/prometheus",
                                            "--storage.tsdb.retention.time=12d"
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
                                                ReadOnly = true
                                            },
                                            new VolumeMountArgs
                                            {
                                                Name = "monitor-data",
                                                MountPath = "/data",
                                                ReadOnly = false
                                            },
                                            new VolumeMountArgs
                                            {
                                                Name = "prometheus-rules",
                                                MountPath = "/prometheus-rules",
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
                                                MountPath = "/data",
                                                ReadOnly = false
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
                                            Name = monitorConfigMap.Metadata.Apply(x => x.Name),
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
                                            Name = monitorConfigMap.Metadata.Apply(x => x.Name),
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
                }, new CustomResourceOptions { DeletedWith = tidbCluster, DependsOn = { tidbCluster } });

            return new TiDBComponentOutput();
        }
    }
}