using System.Collections.Generic;
using System.Text.Json;
using Infrastructure.CDKTF.Construct.Kubernetes.Config;
using Infrastructure.CDKTF.Construct.Storage.Tidb.Crd;
using Release = HashiCorp.Cdktf.Providers.Helm.Release.Release;

namespace Infrastructure.CDKTF.Construct.Storage.Tidb;

internal sealed class TiDb : Constructs.Construct
{
    public TiDb(Constructs.Construct scope, string id, string @namespace, TidbOperatorValues tidbOperatorValues = null) : base(scope, "construct-tidb")
    {
        var ns = new Namespace(scope, "tidb-admin").Apply();
        
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
            DependsOn = [ns.Id]
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
            DependsOn = [crd.Id]
        };

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
            DependsOn = [crd.Id]
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