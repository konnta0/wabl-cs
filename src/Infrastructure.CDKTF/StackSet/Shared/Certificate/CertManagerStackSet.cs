using HashiCorp.Cdktf;
using HashiCorp.Cdktf.Providers.Helm.Release;

namespace Infrastructure.CDKTF.StackSet.Shared.Certificate;

internal sealed class CertManagerStackSet
{
    public CertManagerStackSet(App app, string id)
    {
        // helm search repo cert-manager
        // NAME                                    CHART VERSION   APP VERSION     DESCRIPTION
        // jetstack/cert-manager                   v1.8.0          v1.8.0          A Helm chart for cert-manager
        _ = new Release(app, id, new ReleaseConfig
        {
            Chart = "cert-manager",
            Version = "v1.8.0",
            Repository = "https://charts.jetstack.io",
            Atomic = true,
            CreateNamespace = false
        });

        _ = new TerraformAsset(app, "cert-manager-crds", new TerraformAssetConfig
        {
            Path = "https://github.com/cert-manager/cert-manager/releases/download/v1.8.0/cert-manager.crds.yaml"
        });
    }
}