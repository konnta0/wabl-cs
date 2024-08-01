using HashiCorp.Cdktf;
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
        var ns = new Namespace(construct, "webapp").Apply();
    }
}