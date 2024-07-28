using HashiCorp.Cdktf;
using HashiCorp.Cdktf.Providers.Kubernetes.Provider;
using Infrastructure.CDKTF.StackSet.Shared;
using Infrastructure.CDKTF.StackSet.Tool;
using Infrastructure.CDKTF.StackSet.WebApp;

namespace Infrastructure.CDKTF.Stack;

class LocalStack : TerraformStack
{
    public LocalStack(App app, string id) : base(app, id)
    {
        _ = new KubernetesProvider(this, "k8s", new KubernetesProviderConfig());
        _ = new SharedStackSet(app);
        _ = new ToolStackSet(app);
        _ = new WebAppStackSet(app);
    }
}