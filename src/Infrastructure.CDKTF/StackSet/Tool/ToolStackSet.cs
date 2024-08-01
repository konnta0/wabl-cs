using HashiCorp.Cdktf;
using Infrastructure.CDKTF.Construct;

namespace Infrastructure.CDKTF.StackSet.Tool;

internal sealed class ToolStackSet : TerraformResource
{
    public ToolStackSet(Constructs.Construct construct) :
        base(construct, nameof(ToolStackSet), new TerraformResourceConfig
    {
        TerraformResourceType = "stackset",
    })
    {
        var ns = new Namespace(construct, "tool").Apply();
    }
}