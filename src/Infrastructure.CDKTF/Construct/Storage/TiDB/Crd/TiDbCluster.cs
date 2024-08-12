using System.Collections.Generic;
using System.Text.Json;
using Amazon.JSII.Runtime.Deputy;
using HashiCorp.Cdktf.Providers.Kubernetes.Manifest;
using Infrastructure.CDKTF.Construct.Kubernetes.Config;

namespace Infrastructure.CDKTF.Construct.Storage.Tidb.Crd;

internal sealed class TiDbCluster : Manifest_
{
    public TiDbCluster(Constructs.Construct scope, string id, Metadata metadata, TiDbClusterSpec spec) : base(scope, id,
        new ManifestConfig
        {
            Manifest = new Dictionary<string, object>
            {
                ["apiVersion"] = "pingcap.com/v1alpha1",
                ["kind"] = "TidbCluster",
                ["metadata"] = metadata.ToPair().Value,
                ["spec"] = spec.ToPair().Value
            }
        })
    {
    }
}

public sealed class TidbClusterConfig : IManifestConfig
{
    [JsiiProperty("manifest", "{\"collection\":{\"elementtype\":{\"primitive\":\"any\"},\"kind\":\"map\"}}", false, false)]

    public IDictionary<string, object> Manifest { get; } = new Dictionary<string, object>();
}

internal sealed record TiDbClusterSpec : IKubernetesConfig
{
    public required string Version { get; init; } = "v7.5.0";
    public required string ConfigUpdateStrategy { get; init; } = "RollingUpdate";
    public required PdSpec Pd { get; init; }
    public required TiKvSpec Tikv { get; init; }
    public required TiDbSpec Tidb { get; init; }

    public required int TidbReplicas { get; init; } = 2;
    public required int TikvReplicas { get; init; } = 3;
    
    public KeyValuePair<string, string> ToPair()
    {
        return new KeyValuePair<string, string>("spec", JsonSerializer.Serialize(this, JsonSerializerOption.Default));
    }

    internal sealed record PdSpec : IKubernetesConfig
    {
        public required string BaseImage { get; init; } = "pingcap/pd";
        public required string Version { get; init; } = "v7.5.0";
        public required int Replicas { get; init; } = 2;
        public required Dictionary<string, object> Requests { get; init; } = new ()
        {
            ["storage"] = "10Gi"
        };
        public required List<object> Config { get; init; } = [];
        public KeyValuePair<string, string> ToPair()
        {
            return new KeyValuePair<string, string>("pd", JsonSerializer.Serialize(this, JsonSerializerOption.Default));
        }
    }
    
    internal sealed record TiKvSpec : IKubernetesConfig
    {
        public required string BaseImage { get; init; } = "pingcap/tikv";
        public required string Version { get; init; } = "v7.5.0";
        public required int Replicas { get; init; } = 2;
        public required Dictionary<string, object> Requests { get; init; } = new ()
        {
            ["storage"] = "10Gi"
        };
        public required List<object> Config { get; init; } = [];
        public KeyValuePair<string, string> ToPair()
        {
            return new KeyValuePair<string, string>("pd", JsonSerializer.Serialize(this, JsonSerializerOption.Default));
        }
    }

    internal sealed record TiDbSpec : IKubernetesConfig
    {
        public required string BaseImage { get; init; } = "pingcap/tidb";
        public required string Version { get; init; } = "v7.5.0";
        public required int Replicas { get; init; } = 2;
        public required Dictionary<string, object> Requests { get; init; } = new ()
        {
            ["storage"] = "10Gi"
        };

        public required Dictionary<string, object> SlowLogTailer = new()
        {
            ["image"] = "arm64v8/busybox:1.26.2"
        };
        public required List<object> Config { get; init; } = [];
        public KeyValuePair<string, string> ToPair()
        {
            return new KeyValuePair<string, string>("pd", JsonSerializer.Serialize(this, JsonSerializerOption.Default));
        }
    }
}