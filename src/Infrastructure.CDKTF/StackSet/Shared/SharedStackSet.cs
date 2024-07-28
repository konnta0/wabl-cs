using HashiCorp.Cdktf;
using Infrastructure.CDKTF.Construct;

namespace Infrastructure.CDKTF.StackSet.Shared;

internal sealed class SharedStackSet
{
    public SharedStackSet(App app) 
    {
        var ns = new Namespace(app, "shared").Apply();
    }
}