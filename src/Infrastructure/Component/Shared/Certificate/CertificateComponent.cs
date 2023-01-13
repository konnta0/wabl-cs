using Infrastructure.Component.Shared.Certificate.CertManager;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Component.Shared.Certificate
{
    public class CertificateComponent : IComponent<CertificateComponentInput, CertificateComponentOutput>
    {
        private readonly ILogger<CertificateComponent> _logger;
        private readonly CertManagerComponent _certManagerComponent;

        public CertificateComponent(ILogger<CertificateComponent> logger, CertManagerComponent certManagerComponent)
        {
            _logger = logger;
            _certManagerComponent = certManagerComponent;
        }
        
        public CertificateComponentOutput Apply(CertificateComponentInput input)
        {
            var output = _certManagerComponent.Apply(new CertManagerComponentInput
            {
                Namespace = input.Namespace
            });
            return new CertificateComponentOutput
            {
                ClusterIssuer = output.ClusterIssuer
            };
        }
    }
}