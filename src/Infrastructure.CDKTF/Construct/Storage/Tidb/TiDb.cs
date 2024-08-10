using Release = HashiCorp.Cdktf.Providers.Helm.Release.Release;

namespace Infrastructure.CDKTF.Construct.Storage;

internal sealed class TiDb : Constructs.Construct
{
    public TiDb(Constructs.Construct scope, string id, string @namespace, string[]? values = null) : base(scope, "construct-tidb")
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
            Values = values,
            Namespace = @namespace
        })
        {
            DependsOn = [crd.Id]
        };
        
        // custom resource tidbcluster
    }
}