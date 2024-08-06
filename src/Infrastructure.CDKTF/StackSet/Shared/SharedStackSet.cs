using HashiCorp.Cdktf;
using Infrastructure.CDKTF.StackSet.Shared.Storage;
using Namespace = Infrastructure.CDKTF.Construct.Namespace;

namespace Infrastructure.CDKTF.StackSet.Shared;

internal sealed class SharedStackSet : TerraformResource
{
    public SharedStackSet(Constructs.Construct construct) :
        base(construct, ConstructExtension.ToKebabCase<SharedStackSet>(), new TerraformResourceConfig
    {
        TerraformResourceType = "stack-set",
    })
    {
        var ns = new Namespace(construct, "shared").Apply();
        var minio = new MinIoStackSet(construct)
        {
            DependsOn = [ns.Id]
        };
        var tidb = new TiDbStackSet(construct)
        {
            DependsOn = [ns.Id]
        };
    }
}