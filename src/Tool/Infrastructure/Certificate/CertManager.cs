using Microsoft.Extensions.Logging;
using Pulumi;
using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Helm.V3;
using Pulumi.Kubernetes.Types.Inputs.Core.V1;
using Pulumi.Kubernetes.Types.Inputs.Helm.V3;
using Pulumi.Kubernetes.Types.Inputs.Meta.V1;
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

            var ns = new Namespace("cert-manager-namespace", new NamespaceArgs
            {
                Metadata = new ObjectMetaArgs
                {
                    Name = "cert-manager"
                }
            });

            var crds = new ConfigFile("cert-manager-crds", new ConfigFileArgs
            {
                File = "https://github.com/cert-manager/cert-manager/releases/download/v1.8.0/cert-manager.crds.yaml"
            });
            
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
                Namespace = ns.Metadata.Apply(x => x.Name),
                Timeout = 60 * 10,
                Atomic = true
            });
            
            var ca = new ConfigFile("ca", new ConfigFileArgs
            {
                File = "./Certificate/yaml/ca.yaml"
            });
            Namespace = ns.Metadata.Apply(x => x.Name);
        }

        [Output] public Output<string> Namespace { get; private set; }
    }
}