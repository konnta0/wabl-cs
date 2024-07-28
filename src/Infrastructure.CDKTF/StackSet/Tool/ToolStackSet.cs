using HashiCorp.Cdktf;
using Infrastructure.CDKTF.Construct;

namespace Infrastructure.CDKTF.StackSet.Tool;

internal sealed class ToolStackSet
{
    public ToolStackSet(App app)
    {
        var ns = new Namespace(app, "tool").Apply();
    }
}