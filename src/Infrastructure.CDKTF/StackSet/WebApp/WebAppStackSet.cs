using HashiCorp.Cdktf;
using HashiCorp.Cdktf.Providers.Kubernetes.Namespace;
using Infrastructure.CDKTF.Construct;

namespace Infrastructure.CDKTF.StackSet.WebApp;

internal sealed class WebAppStackSet : TerraformResource
{
    public WebAppStackSet(Constructs.Construct construct) :
        base(construct, nameof(WebAppStackSet), new TerraformResourceConfig
        {
            TerraformResourceType = "stackset",
        })
    {
        var ns = new Namespace(construct, "namespace-webapp", new NamespaceConfig { Metadata = new NamespaceMetadata { Name = "webapp"}});
    }
}