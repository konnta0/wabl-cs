namespace Infrastructure.CDKTF.Construct.Storage;

internal sealed class Redis : Constructs.Construct
{
    public Redis(Constructs.Construct scope, string id, string @namespace, string[]? values = null) : base(scope, "construct-redis")
    {
        _ = new HashiCorp.Cdktf.Providers.Helm.Release.Release(scope, id, new HashiCorp.Cdktf.Providers.Helm.Release.ReleaseConfig
        {
            Name = id,
            Chart = "redis-ha",
            Version = "4.22.4",
            Repository = "https://dandydeveloper.github.io/charts",
            Atomic = true,
            CreateNamespace = false,
            Values = values,
            Namespace = @namespace
        });
    }
}