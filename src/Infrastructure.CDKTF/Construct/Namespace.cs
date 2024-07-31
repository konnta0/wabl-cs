using HashiCorp.Cdktf.Providers.Kubernetes.Namespace;
using Ns = HashiCorp.Cdktf.Providers.Kubernetes.Namespace.Namespace;

namespace Infrastructure.CDKTF.Construct;

public sealed class Namespace(Constructs.Construct construct, string name)
    : Constructs.Construct(construct, $"construct-namespace-{name}"), IApplicableConstruct<Ns>
{
    private readonly Constructs.Construct _construct = construct;
    private readonly string _name = $"namespace-{name}";

    public Ns Apply()
    {
        return new Ns(_construct, _name, new NamespaceConfig
        {
            Metadata = new NamespaceMetadata
            {
                Name = _name
            }
        });
    }
}