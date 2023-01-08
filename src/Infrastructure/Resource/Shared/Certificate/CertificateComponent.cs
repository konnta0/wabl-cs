using System.Threading.Tasks;
using Infrastructure.Resource.Shared.Certificate.CertManager;
using Microsoft.Extensions.Logging;
using Pulumi;

namespace Infrastructure.Resource.Shared.Certificate
{
    public class CertificateComponent
    {
        private readonly ILogger<CertificateComponent> _logger;
        private readonly CertManagerResource _certManagerResource;

        public CertificateComponent(ILogger<CertificateComponent> logger, CertManagerResource certManagerResource)
        {
            _logger = logger;
            _certManagerResource = certManagerResource;
        }

        public void Apply(Pulumi.Kubernetes.Core.V1.Namespace @namespace)
        {
            _certManagerResource.Apply(@namespace);
        }
    }
}