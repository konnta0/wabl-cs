using Infrastructure.Pulumi.Component.Shared.Certificate.CertManager;

namespace Infrastructure.Pulumi.Component.Shared.Certificate;

public class CertificateComponent(CertManagerComponent certManagerComponent)
    : IComponent<CertificateComponentInput, CertificateComponentOutput>
{
    public CertificateComponentOutput Apply(CertificateComponentInput input)
    {
        var output = certManagerComponent.Apply(new CertManagerComponentInput
        {
            Namespace = input.Namespace
        });
        return new CertificateComponentOutput
        {
            ClusterIssuer = output.ClusterIssuer
        };
    }
}