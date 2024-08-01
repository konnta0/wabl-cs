using HashiCorp.Cdktf;
using HashiCorp.Cdktf.Providers.Helm.Provider;
using HashiCorp.Cdktf.Providers.Kubernetes.Provider;
using Infrastructure.CDKTF.StackSet.Shared;
using Infrastructure.CDKTF.StackSet.Tool;
using Infrastructure.CDKTF.StackSet.WebApp;

namespace Infrastructure.CDKTF.Stack;

internal sealed class LocalStack : TerraformStack
{
    public LocalStack(App app, string id) : base(app, id)
    {
        var value = new Environment.Local.EnvironmentValue();

        _ = new KubernetesProvider(this, "k8s-provider", new KubernetesProviderConfig());
        _ = new HelmProvider(this, "helm-provider", new HelmProviderConfig());

        _ = new SharedStackSet(this);
        _ = new ToolStackSet(this);
        _ = new WebAppStackSet(this);
    }
}