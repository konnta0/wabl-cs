using Constructs;
using HashiCorp.Cdktf;
using HashiCorp.Cdktf.Providers.Kubernetes.Namespace;
using HashiCorp.Cdktf.Providers.Kubernetes.Provider;

namespace Infrastructure.CDKTF;

class MainStack : TerraformStack
{
    public MainStack(Construct scope, string id) : base(scope, id)
    {
        _ = new KubernetesProvider(this, "k8s", new KubernetesProviderConfig());

        var sharedNamespace = new Namespace(this, "namespace-shared", new NamespaceConfig
        {
            Metadata = new NamespaceMetadata
            {
                Name = "shared"
            }
        });

        var toolNamespace = new Namespace(this, "namespace-tool", new NamespaceConfig
        {
            Metadata = new NamespaceMetadata
            {
                Name = "tool"
            }
        });

        var webappNamespace = new Namespace(this, "namespace-webapp", new NamespaceConfig
        {
            Metadata = new NamespaceMetadata
            {
                Name = "webapp"
            }
        });

        var certManagerModule = new Modules.Certificate.CertManagerModule(this, "cert-manager",
            new Modules.Certificate.CertManagerConfig(sharedNamespace));
        
    }
}