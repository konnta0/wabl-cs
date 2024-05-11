using System.Collections.Generic;
using Pulumi;
using Pulumi.Crds.Pingcap.V1Alpha1;
using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Helm.V3;
using Pulumi.Kubernetes.Types.Inputs.Core.V1;
using Pulumi.Kubernetes.Types.Inputs.Helm.V3;
using Pulumi.Kubernetes.Types.Inputs.Meta.V1;
using Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.Pulumi.Component.Shared.Storage.TiDB
{
    public class TiDBComponent(Config config) : IComponent<TiDBComponentInput, TiDBComponentOutput>
    {
        private readonly Config _config = config;

        public TiDBComponentOutput Apply(TiDBComponentInput input)
        {
            var tidbAdminNamespace = new Namespace("namespace-tidb-admin", new NamespaceArgs
            {
                Metadata = new ObjectMetaArgs
                {
                    Name = "tidb-admin"
                }
            });
            
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
                Namespace = tidbAdminNamespace.Metadata.Apply(x => x.Name)
            }, new CustomResourceOptions { DependsOn = { configFile } });

            // note: if you use microk8s, you need to use the following command to update file descriptor limit 
            // https://github.com/canonical/microk8s/issues/1096#issuecomment-610264253
            // sudo vi /var/snap/microk8s/current/args/containerd-env
            // ulimit -n 1048576
            // microk8s.stop; microk8s.start

            var cluster = new TidbCluster("tidb-cluster", new TidbClusterArgs
            {
                Metadata = new ObjectMetaArgs
                {
                    Name = "tidb-cluster",
                    Namespace = input.Namespace.Metadata.Apply(x => x.Name)
                },
                Spec = new TidbClusterSpecArgs
                {
                    Version = "v7.5.0",
                    ConfigUpdateStrategy = "RollingUpdate",
                    Pd = new TidbClusterSpecPdArgs
                    {
                        BaseImage = "pingcap/pd",
                        Version = "v7.5.0",
                        Replicas = 2,
                        Requests = new InputMap<Union<int, string>>
                        {
                            ["storage"] = Union<int, string>.FromT1("10Gi")
                        },
                        Config = []
                    },
                    Tikv = new TidbClusterSpecTikvArgs
                    {
                        BaseImage = "pingcap/tikv",
                        Version = "v7.5.0",
                        Replicas = 2,
                        Requests = new InputMap<Union<int, string>>
                        {
                            ["storage"] = Union<int, string>.FromT1("10Gi")
                        },
                        Config = []
                    },
                    Tidb = new TidbClusterSpecTidbArgs
                    {
                        BaseImage = "pingcap/tidb",
                        Version = "v7.5.0",
                        SlowLogTailer = new TidbClusterSpecTidbSlowLogTailerArgs
                        {
                            Image = "arm64v8/busybox:1.26.2"
                        },
                        Replicas = 2,
                        Requests = new InputMap<Union<int, string>>
                        {
                            ["storage"] = Union<int, string>.FromT1("10Gi")
                        },
                        Service = new TidbClusterSpecTidbServiceArgs
                        {
                            Type = "LoadBalancer"
                        },
                        Config = []
                    },
                    // Discovery = new TidbClusterSpecDiscoveryArgs
                    // {
                    //     Image = "pingcap/tidb-discovery",
                    //     Limits = new InputMap<Union<int, string>>
                    //     {
                    //         ["cpu"] = Union<int, string>.FromT1("0.2")
                    //     },
                    //     Requests = new InputMap<Union<int, string>>
                    //     {
                    //         ["cpu"] = Union<int, string>.FromT1("0.2")
                    //     }
                    // },
                    // Tiflash = new TidbClusterSpecTiflashArgs
                    // {
                    //     BaseImage = "pingcap/tiflash",
                    //     //Version = "v7.5.0",
                    //     MaxFailoverCount = 0,
                    //     Replicas = 1,
                    //     StorageClaims = new InputList<TidbClusterSpecTiflashStorageClaimsArgs>
                    //     {
                    //         new TidbClusterSpecTiflashStorageClaimsArgs
                    //         {
                    //             StorageClassName = "microk8s-hostpath",
                    //             Resources = new TidbClusterSpecTiflashStorageClaimsResourcesArgs
                    //             {
                    //                 Requests =
                    //                 {
                    //                     ["storage"] = Union<int, string>.FromT1("5Gi")
                    //                 }
                    //             }
                    //         }
                    //     }
                    // },
                    // Pump = new TidbClusterSpecPumpArgs
                    // {
                    //     BaseImage = "pingcap/tidb-binlog",
                    //     //Version = "v7.5.0",
                    //     Replicas = 1,
                    //     Requests = new InputMap<Union<int, string>>
                    //     {
                    //         ["storage"] = Union<int, string>.FromT1("2Gi")
                    //     }
                    // },
                    // Ticdc = new TidbClusterSpecTicdcArgs
                    // {
                    //     BaseImage = "pingcap/ticdc",
                    //     //Version = "v7.5.0",
                    //     Replicas = 1
                    // },
                    // Helper = new TidbClusterSpecHelperArgs
                    // {
                    //     Image = "alpine:3.16.0"
                    // }
                }
            }, new CustomResourceOptions
            {
                DeleteBeforeReplace = true,
            });

            var initializer = new TidbInitializer("tidb-initializer", new TidbInitializerArgs
            {
                Metadata = new ObjectMetaArgs
                {
                    Namespace = input.Namespace.Metadata.Apply(x => x.Name)
                },
                Spec = new TidbInitializerSpecArgs
                {
                    Image = "kanshiori/mysqlclient-arm64",
                    Cluster = new TidbInitializerSpecClusterArgs
                    {
                        Name = cluster.Metadata.Apply(x => x.Name),
                        Namespace = cluster.Metadata.Apply(static x => x.Namespace)
                    },
                    InitSql = "CREATE DATABASE IF NOT EXISTS app_db;\nCREATE USER IF NOT EXISTS 'developer' IDENTIFIED BY '3edc4rfv5';\nGRANT ALL PRIVILEGES ON app_db.* TO 'developer'@'%';",
                }
            }, new CustomResourceOptions
            {
                DeleteBeforeReplace = true,
            });

            return new();
            var monitor = new TidbMonitor("tidb-monitor", new TidbMonitorArgs
            {
                Metadata = new ObjectMetaArgs
                {
                    Name = "tidb-monitor",
                    Namespace = input.Namespace.Metadata.Apply(x => x.Name)
                },
                Spec = new TidbMonitorSpecArgs
                {
                    Clusters = new TidbMonitorSpecClustersArgs
                    {
                        Name = "tidb-cluster",
                        Namespace = input.Namespace.Metadata.Apply(x => x.Name)  
                    },
                    Initializer = new TidbMonitorSpecInitializerArgs
                    {
                        BaseImage = "pingcap/tidb-monitor-initializer",
                        Version = "v5.4.2"
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
                    Reloader = new TidbMonitorSpecReloaderArgs
                    {
                        BaseImage = "pingcap/tidb-monitor-reloader",
                        Version = "v1.0.1"
                    }
                }
            });
            
            return new TiDBComponentOutput();
        }
    }
}