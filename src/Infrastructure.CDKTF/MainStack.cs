using Constructs;
using HashiCorp.Cdktf;

namespace Infrastructure.CDKTF;

class MainStack : TerraformStack
{
    public MainStack(Construct scope, string id) : base(scope, id)
    {
        // define resources here
    }
}