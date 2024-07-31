using HashiCorp.Cdktf;
using Namespace = Infrastructure.CDKTF.Construct.Namespace;

namespace Infrastructure.CDKTF.StackSet.Shared;

internal sealed class SharedStackSet : TerraformResource
{
    public SharedStackSet(Constructs.Construct construct, TerraformProvider provider) :
        base(construct, nameof(SharedStackSet), new TerraformResourceConfig
    {
        TerraformResourceType = "stackset",
        Provider = provider
    })
    {
        var ns = new Namespace(construct, "shared").Apply();
    }
}