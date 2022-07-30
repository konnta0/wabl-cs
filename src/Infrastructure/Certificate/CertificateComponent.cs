using Microsoft.Extensions.Logging;
using Pulumi;

namespace Infrastructure.Certificate
{
    public class CertificateComponent
    {
        private readonly ILogger<CertificateComponent> _logger;
        private readonly CertManager _certManager;

        public CertificateComponent(ILogger<CertificateComponent> logger, CertManager certManager)
        {
            _logger = logger;
            _certManager = certManager;
        }

        public void Apply()
        {
            _certManager.Apply();
        }

        [Output] private Output<string> Namespace => _certManager.Namespace;
    }
}