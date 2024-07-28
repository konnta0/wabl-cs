using HashiCorp.Cdktf;
using Infrastructure.CDKTF.Construct;

namespace Infrastructure.CDKTF.StackSet.WebApp;

internal sealed class WebAppStackSet
{
    public WebAppStackSet(App app)
    {
        var ns = new Namespace(app, "webapp").Apply();
    }
}