using System.Threading.Tasks;
using Infrastructure.Resource.Shared.Certificate.CertManager;
using Microsoft.Extensions.Logging;
using Pulumi;

namespace Infrastructure.Resource.Shared.Certificate
{
    public class CertificateComponent
    {
        private readonly ILogger<CertificateComponent> _logger;
        private readonly CertManagerComponent _certManagerComponent;

        public CertificateComponent(ILogger<CertificateComponent> logger, CertManagerComponent certManagerComponent)
        {
            _logger = logger;
            _certManagerComponent = certManagerComponent;
        }

        public void Apply(Pulumi.Kubernetes.Core.V1.Namespace @namespace)
        {
            _certManagerComponent.Apply(@namespace);
        }
    }
}