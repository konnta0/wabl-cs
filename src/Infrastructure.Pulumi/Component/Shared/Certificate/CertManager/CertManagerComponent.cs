using Microsoft.Extensions.Logging;
using Pulumi;
using Pulumi.Crds.Certmanager.V1;
using Pulumi.Kubernetes.Helm.V3;
using Pulumi.Kubernetes.Types.Inputs.Certmanager.V1;
using Pulumi.Kubernetes.Types.Inputs.Helm.V3;
using Pulumi.Kubernetes.Types.Inputs.Meta.V1;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.Pulumi.Component.Shared.Certificate.CertManager
{
    public class CertManagerComponent : IComponent<CertManagerComponentInput, CertManagerComponentOutput>
    {
        private readonly ILogger<CertManagerComponent> _logger;

        public CertManagerComponent(ILogger<CertManagerComponent> logger)
        {
            _logger = logger;
        }
        

        public CertManagerComponentOutput Apply(CertManagerComponentInput input)
        {
            var crds = new ConfigFile("cert-manager-crds", new ConfigFileArgs
            {
                File = "https://github.com/cert-manager/cert-manager/releases/download/v1.8.0/cert-manager.crds.yaml"
            });
            crds.Ready();

            var ns = string.Empty;
            input.Namespace.Metadata.Apply(x =>
            {
                ns = x.Name;
                return x.Name;
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
                Namespace = input.Namespace.Metadata.Apply(x => x.Name),
                Atomic = true
            });

            var clusterIssuer = new ClusterIssuer("cluster-issuer", new ClusterIssuerArgs
            {
                Metadata = new ObjectMetaArgs
                {
                    Name = "selfsigned-issuer",
                    Namespace = "shared"
                },
                Spec = new ClusterIssuerSpecArgs
                {
                    SelfSigned = new ClusterIssuerSpecSelfsignedArgs()
                }
            },  new CustomResourceOptions { DependsOn = {crds, certManager}, DeletedWith = crds});

            var certificate = new global::Pulumi.Crds.Certmanager.V1.Certificate("certificate", new CertificateArgs
            {
                Metadata = new ObjectMetaArgs
                {
                    Name = "selfsigned-ca",
                    Namespace = input.Namespace.Metadata.Apply(x => x.Name)
                },
                Spec = new CertificateSpecArgs
                {
                    IsCA = true,
                    CommonName = "selfsigned-ca",
                    Duration = "438000h",
                    SecretName = "selfsigned-ca-cert",
                    PrivateKey = new CertificateSpecPrivatekeyArgs
                    {
                        Algorithm = "RSA",
                        Size = 2048
                    },
                    IssuerRef = new CertificateSpecIssuerrefArgs
                    {
                        Name = clusterIssuer.Metadata.Apply(x => x.Name),
                        Kind = nameof(ClusterIssuer),
                        Group = "cert-manager.io"
                    }
                }
            }, new CustomResourceOptions {DependsOn = {crds, certManager}, DeletedWith = crds});

            return new CertManagerComponentOutput
            {
                ClusterIssuer = clusterIssuer
            };
        }
    }
}