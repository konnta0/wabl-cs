using Microsoft.Extensions.Logging;
using Pulumi;
using Pulumi.Kubernetes.Helm.V3;
using Pulumi.Kubernetes.Types.Inputs.Helm.V3;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.Certificate
{
    public class CertManager
    {
        private readonly ILogger<CertManager> _logger;

        public CertManager(ILogger<CertManager> logger)
        {
            _logger = logger;
        }

        public void Apply()
        {

            var certManager = new Release("cert-manager", new ReleaseArgs
            {
                Chart = "cert-manager",
                // helm search repo cert-manager
                // NAME                                    CHART VERSION   APP VERSION     DESCRIPTION
                // jetstack/cert-manager                   v1.8.0          v1.8.0          A Helm chart for cert-manager
                Version = "v1.8.0",
                RepositoryOpts = new RepositoryOptsArgs
                {
                    Repo = "https://charts.jetstack.io"
                },
                CreateNamespace = true,
                Namespace = "certificate",
                Timeout = 60 * 10,
                Atomic = true
            });
            
            var ca = new ConfigFile("ca", new ConfigFileArgs
            {
                File = "./Certificate/yaml/ca.yaml"
            });
            Namespace = certManager.Namespace;
        }

        [Output] public Output<string> Namespace { get; private set; }
    }
}