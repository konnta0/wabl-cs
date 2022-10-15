using System.Collections.Generic;
using System.Collections.Immutable;
using Infrastructure.Extension;
using Pulumi;
using Pulumi.Kubernetes.Helm.V3;
using Pulumi.Kubernetes.Types.Inputs.Helm.V3;
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
                File = "./WebApplication/Resource/TiDB/Yaml/crd.yaml",
                Transformations =
                {
                    // (ImmutableDictionary<string, object> obj, CustomResourceOptions opts) =>
                    // {
                    //     var metadata = (ImmutableDictionary<string, object>)obj["metadata"];
                    //     if (!metadata.ContainsKey("namespace"))
                    //     {
                    //         return obj.SetItem("metadata", metadata.Add("namespace", _config.GetWebApplicationConfig().Namespace));
                    //     }
                    //     
                    //     return obj.SetItem("metadata", metadata.SetItem("namespace", _config.GetWebApplicationConfig().Namespace));
                    // }
                }
            });
            configFile.Ready();

            // var localVolumeProvisioner = new ConfigFile("web-application-tidb-local-volume-provisioner", new ConfigFileArgs
            // {
            //     File = "./WebApplication/Resource/TiDB/Yaml/local-volume-provisioner.yaml",
            // });
            // localVolumeProvisioner.Ready();

            var tidbOperator = new Release("web-application-tidb-operator", new ReleaseArgs
            {
                Chart = "tidb-operator",
                // helm search repo pingcap/tidb-operator --versions
                // NAME                    CHART VERSION   APP VERSION     DESCRIPTION
                // pingcap/tidb-operator   v1.3.8          v1.3.8          tidb-operator Helm chart for Kubernetes
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
                }
            };

            var tidbCluster = new Release("web-application-tidb-cluster", new ReleaseArgs
            {
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
        }
    }
}