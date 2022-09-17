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
                    (ImmutableDictionary<string, object> obj, CustomResourceOptions opts) =>
                    {
                        var metadata = (ImmutableDictionary<string, object>)obj["metadata"];
                        if (!metadata.ContainsKey("namespace")) return obj;
                        return obj.SetItem("metadata", metadata.SetItem("namespace", "tekton-pipelines"));
                    }
                }
            });

            configFile.Ready();

            var tidbOperator = new Release("web-application-tidb-operator", new ReleaseArgs
            {
                Chart = "tidb-operator",
                // helm search repo pingcap/tidb-operator --versions | head -n 10
                // NAME                    CHART VERSION   APP VERSION     DESCRIPTION
                // pingcap/tidb-operator   v1.3.7          v1.3.7          tidb-operator Helm chart for Kubernetes
                // pingcap/tidb-operator   v1.3.6          v1.3.6          tidb-operator Helm chart for Kubernetes
                // pingcap/tidb-operator   v1.3.5          v1.3.5          tidb-operator Helm chart for Kubernetes
                // pingcap/tidb-operator   v1.3.4          v1.3.4          tidb-operator Helm chart for Kubernetes
                // pingcap/tidb-operator   v1.3.3          v1.3.3          tidb-operator Helm chart for Kubernetes
                // pingcap/tidb-operator   v1.3.2          v1.3.2          tidb-operator Helm chart for Kubernetes
                // pingcap/tidb-operator   v1.3.1          v1.3.1          tidb-operator Helm chart for Kubernetes
                // pingcap/tidb-operator   v1.3.0          v1.3.0          tidb-operator Helm chart for Kubernetes
                // pingcap/tidb-operator   v1.2.7          v1.2.7          tidb-operator Helm chart for Kubernetes
                Version = "v1.3.7",
                RepositoryOpts = new RepositoryOptsArgs
                {
                    Repo = "https://charts.pingcap.org"
                },
                CreateNamespace = false,
                Atomic = true,
                Namespace = _config.GetWebApplicationConfig().Namespace
            });

            // https: //github.com/pingcap/tidb-operator/blob/master/charts/tidb-cluster/values.yaml
            var values = new Dictionary<string, object>
            {
                ["pd"] = new Dictionary<string, object>
                {
                    ["storageClassName"] = "standard",
                    ["replicas"] = 2
                    
                },
                ["tikv"] = new Dictionary<string, object>
                {
                    ["storageClassName"] = "standard",
                    ["replicas"] = 2,
                    ["resources"] = new Dictionary<string, object>
                    {
                        ["limits"] = new Dictionary<string, object>
                        {
                            ["memory"] = "700Mi"
                        }
                    }
                }
            };
            var tidbCluster = new Release("web-application-tidb-cluster", new ReleaseArgs
            {
                Chart = "tidb-cluster",
                // helm search repo pingcap/tidb-cluster --versions | head -n 10
                // NAME                    CHART VERSION   APP VERSION     DESCRIPTION
                // pingcap/tidb-cluster    v1.3.7                          A Helm chart for TiDB Cluster
                // pingcap/tidb-cluster    v1.3.6                          A Helm chart for TiDB Cluster
                // pingcap/tidb-cluster    v1.3.5                          A Helm chart for TiDB Cluster
                // pingcap/tidb-cluster    v1.3.4                          A Helm chart for TiDB Cluster
                // pingcap/tidb-cluster    v1.3.3                          A Helm chart for TiDB Cluster
                // pingcap/tidb-cluster    v1.3.2                          A Helm chart for TiDB Cluster
                // pingcap/tidb-cluster    v1.3.1                          A Helm chart for TiDB Cluster
                // pingcap/tidb-cluster    v1.3.0                          A Helm chart for TiDB Cluster
                // pingcap/tidb-cluster    v1.2.7                          A Helm chart for TiDB Cluster
                Version = "v1.3.7",
                RepositoryOpts = new RepositoryOptsArgs
                {
                    Repo = "https://charts.pingcap.org"
                },
                CreateNamespace = false,
                Atomic = true,
                Values = values,
                Namespace = tidbOperator.Namespace.Apply(x => x)
            });
        }
    }
}