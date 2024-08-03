using HashiCorp.Cdktf.Providers.Helm.Release;

namespace Infrastructure.CDKTF.Construct.Storage;

internal sealed class MinIo : Constructs.Construct
{
    public MinIo(Constructs.Construct scope, string id, string[]? values = null) : base(scope, "construct-minio")
    {
        _ = new Release(scope, id, new ReleaseConfig
        {
            Name = id,
            Chart = "minio",
            Version = "4.0.15",
            Repository = "https://charts.min.io",
            Atomic = true,
            CreateNamespace = false,
            Values = values
        });
    }
}