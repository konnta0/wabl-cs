using System.Collections.Generic;
using Constructs;
using HashiCorp.Cdktf;
using HashiCorp.Cdktf.Providers.Helm.Release;
using HashiCorp.Cdktf.Providers.Kubernetes.Manifest;

namespace Infrastructure.CDKTF.Modules.Certificate;

public sealed class CertManagerModule : TerraformModule
{
    public CertManagerModule(Construct scope, string id, CertManagerConfig config) : base(scope, id, config)
    {
        // helm search repo cert-manager
        // NAME                                    CHART VERSION   APP VERSION     DESCRIPTION
        // jetstack/cert-manager                   v1.8.0          v1.8.0          A Helm chart for cert-manager
        _ = new Release(this, id, new ReleaseConfig
        {
            Chart = "cert-manager",
            Version = "v1.8.0",
            Repository = "https://charts.jetstack.io",
            Atomic = true,
            CreateNamespace = false
        });

        new TerraformAsset(this, "cert-manager-crds", new TerraformAssetConfig
        {
            Path = "https://github.com/cert-manager/cert-manager/releases/download/v1.8.0/cert-manager.crds.yaml"
        });
        var data = new DataConfig();
        
        new Manifest_(scope, id, new ManifestConfig
        {
            Manifest = new Dictionary<string, object>()
        });
    }
}