using System.Collections.Generic;
using System.Text.Json;
using HashiCorp.Cdktf.Providers.Kubernetes.Namespace;
using Infrastructure.CDKTF.Construct.Kubernetes.Config;
using Infrastructure.CDKTF.Construct.Storage.Tidb.Crd;
using Release = HashiCorp.Cdktf.Providers.Helm.Release.Release;

namespace Infrastructure.CDKTF.Construct.Storage.Tidb;

internal sealed class TiDb : Constructs.Construct
{
    public TiDb(Constructs.Construct scope, string id, string @namespace, TidbOperatorValues tidbOperatorValues) : base(scope, "construct-tidb")
    {
        var ns = new Namespace(scope, "namespace-tidb-admin", new NamespaceConfig { Metadata = new NamespaceMetadata { Name = "tidb-admin"}});

        var crd = new Release(scope, "tidb-crd", new HashiCorp.Cdktf.Providers.Helm.Release.ReleaseConfig
        {
            Name = "tidb-crd",
            Chart = "tidb-crd",
            Repository = "https://raw.githubusercontent.com/pingcap/tidb-operator/v1.5.1/manifests/crd.yaml",
            Atomic = true,
            CreateNamespace = false,
            Namespace = @namespace
        })
        {
            DependsOn = ["namespace-tidb-admin"]
        };

        var tidbOperator = new Release(scope, "tidb-operator", new HashiCorp.Cdktf.Providers.Helm.Release.ReleaseConfig
        {
            Name = "tidb-operator",
            Chart = "tidb-operator",
            Version = "v1.5.1",
            Repository = "https://charts.pingcap.org",
            Atomic = true,
            CreateNamespace = false,
            Values = tidbOperatorValues.ToArrayString(),
            Namespace = @namespace
        })
        {
            DependsOn = ["tidb-crd"]
        };

        // TODO: Use cdk8s when it supports CRD
        // https://github.com/cdk8s-team/cdk8s-cli/pull/2519
        var tidbCluster = new TiDbCluster(scope,
            "tidb-cluster",
            new Metadata
            {
                Name = "tidb-cluster",
                Namespace = @namespace
            },
            new TiDbClusterSpec
            {
                Version = "v4.0.0",
                TidbReplicas = 2,
                TikvReplicas = 3,
                ConfigUpdateStrategy = "RollingUpdate",
                Pd = new TiDbClusterSpec.PdSpec
                {
                    BaseImage = "pingcap/pd",
                    Version = "v7.5.0",
                    Replicas = 2,
                    Requests = new Dictionary<string, object>
                    {
                        ["storage"] = "10Gi"
                    },
                    Config = []
                },
                Tikv = new TiDbClusterSpec.TiKvSpec
                {
                    BaseImage = "pingcap/tikv",
                    Version = "v7.5.0",
                    Replicas = 2,
                    Requests = new Dictionary<string, object>
                    {
                        ["storage"] = "10Gi"
                    },
                    Config = []
                },
                Tidb = new TiDbClusterSpec.TiDbSpec
                {
                    BaseImage = "pingcap/tikv",
                    Version = "v7.5.0",
                    Replicas = 2,
                    Requests = new Dictionary<string, object>
                    {
                        ["storage"] = "10Gi"
                    },
                    SlowLogTailer = new Dictionary<string, object>
                    {
                        ["image"] = "arm64v8/busybox:1.26.2"
                    },
                    Config = []
                }
            }
        )
        {
            DependsOn = ["tidb-crd"]
        };
    }
}

internal sealed record TidbOperatorValues
{
    public Dictionary<string, object> Scheduler { get; init; } = new ()
    {
        ["create"] = false
    };

    public string[] ToArrayString()
    {
        return [JsonSerializer.Serialize(this, JsonSerializerOption.Default)];
    }
}