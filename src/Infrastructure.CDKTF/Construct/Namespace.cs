using HashiCorp.Cdktf;
using HashiCorp.Cdktf.Providers.Kubernetes.Namespace;
using Ns = HashiCorp.Cdktf.Providers.Kubernetes.Namespace.Namespace;

namespace Infrastructure.CDKTF.Construct;

public sealed class Namespace(App app, string name) : IApplicableConstruct<Ns>
{
    public Ns Apply()
    {
        return new Ns(app, $"namespace-{name}", new NamespaceConfig
        {
            Metadata = new NamespaceMetadata
            {
                Name = name
            }
        });
    }
}