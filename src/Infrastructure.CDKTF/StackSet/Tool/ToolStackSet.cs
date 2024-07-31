using HashiCorp.Cdktf;
using Infrastructure.CDKTF.Construct;

namespace Infrastructure.CDKTF.StackSet.Tool;

internal sealed class ToolStackSet : TerraformResource
{
    public ToolStackSet(Constructs.Construct construct, TerraformProvider provider) :
        base(construct, nameof(ToolStackSet), new TerraformResourceConfig
    {
        TerraformResourceType = "stackset",
        Provider = provider
    })
    {
        var ns = new Namespace(construct, "tool").Apply();
    }
}