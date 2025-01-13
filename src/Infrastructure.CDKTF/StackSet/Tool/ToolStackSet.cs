using HashiCorp.Cdktf;
using HashiCorp.Cdktf.Providers.Kubernetes.Namespace;

namespace Infrastructure.CDKTF.StackSet.Tool;

internal sealed class ToolStackSet : TerraformResource
{
    public ToolStackSet(Constructs.Construct construct) :
        base(construct, ConstructExtension.ToKebabCase<ToolStackSet>(), new TerraformResourceConfig
    {
        TerraformResourceType = "stack-set"
    })
    {
        var ns = new Namespace(construct, "namespace-tool", new NamespaceConfig { Metadata = new NamespaceMetadata { Name = "tool"}});
    }
}