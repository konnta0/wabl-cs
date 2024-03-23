using HashiCorp.Cdktf;
using HashiCorp.Cdktf.Providers.Kubernetes.Namespace;

namespace Infrastructure.CDKTF.Modules.Certificate;

public class CertManagerConfig(Namespace Namespace) : ITerraformModuleConfig
{
    public string Source { get; }
}