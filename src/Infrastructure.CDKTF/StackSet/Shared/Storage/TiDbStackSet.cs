using HashiCorp.Cdktf;
using Infrastructure.CDKTF.Construct.Storage.Tidb;

namespace Infrastructure.CDKTF.StackSet.Shared.Storage;

internal sealed class TiDbStackSet : TerraformResource
{
    public TiDbStackSet(Constructs.Construct scope) :
        base(scope, ConstructExtension.ToKebabCase<TiDbStackSet>(),
            new TerraformResourceConfig
            {
                TerraformResourceType = "stack-set",
            })
    {

        _ = new TiDb(scope, "shared-tidb", "shared", new TidbOperatorValues());
    }
}