using HashiCorp.Cdktf;
using Infrastructure.CDKTF.Construct;

namespace Infrastructure.CDKTF.StackSet.Tool;

internal sealed class ToolStackSet : TerraformResource
{
    public ToolStackSet(Constructs.Construct construct) :
        base(construct, ConstructExtension.ToKebabCase<ToolStackSet>(), new TerraformResourceConfig
    {
        TerraformResourceType = "stack-set"
    })
    {
        var ns = new Namespace(construct, "tool").Apply();
    }
}