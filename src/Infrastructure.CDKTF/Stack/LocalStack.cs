using HashiCorp.Cdktf;
using HashiCorp.Cdktf.Providers.Kubernetes.Provider;
using Infrastructure.CDKTF.StackSet.Shared;
using Infrastructure.CDKTF.StackSet.Tool;
using Infrastructure.CDKTF.StackSet.WebApp;

namespace Infrastructure.CDKTF.Stack;

internal sealed class LocalStack : TerraformStack
{
    public LocalStack(App app, string id) : base(app, id)
    {
        var provider = new KubernetesProvider(this, "k8s", new KubernetesProviderConfig());
        _ = new SharedStackSet(this, provider);
        _ = new ToolStackSet(this, provider);
        _ = new WebAppStackSet(app);
    }
}