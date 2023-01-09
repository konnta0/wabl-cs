using Microsoft.Extensions.Logging;
using Pulumi;
using Pulumi.Crds.Certmanager.V1;
using Pulumi.Kubernetes.Types.Inputs.Certmanager.V1;
using Pulumi.Kubernetes.Types.Inputs.Meta.V1;
using Pulumi.Kubernetes.Yaml;
using Pulumi.KubernetesCertManager;
using Pulumi.KubernetesCertManager.Inputs;

namespace Infrastructure.Component.Shared.Certificate.CertManager
{
    public class CertManagerComponent
    {
        private readonly ILogger<CertManagerComponent> _logger;

        public CertManagerComponent(ILogger<CertManagerComponent> logger)
        {
            _logger = logger;
        }

        public void Apply(Pulumi.Kubernetes.Core.V1.Namespace @namespace)
        {
            var crds = new ConfigFile("cert-manager-crds", new ConfigFileArgs
            {
                File = "https://github.com/cert-manager/cert-manager/releases/download/v1.8.0/cert-manager.crds.yaml"
            });
            crds.Ready();

            var ns = string.Empty;
            @namespace.Metadata.Apply(x =>
            {
                ns = x.Name;
                return x.Name;
            });

            var certManager = new Pulumi.KubernetesCertManager.CertManager("cert-manager", new CertManagerArgs
            {
                InstallCRDs = false,
                ClusterResourceNamespace = ns,
                Webhook = new CertManagerWebhookArgs
                {
                    TimeoutSeconds = 30
                },
                HelmOptions = new ReleaseArgs
                {
                    Namespace = ns,
                    Timeout = 600,
                    Atomic = true,
                    Version = "v1.8.0"
                }
            }, new ComponentResourceOptions { DependsOn = { crds } });

            var clusterIssuer = new ClusterIssuer("cluster-issuer", new ClusterIssuerArgs
            {
                Metadata = new ObjectMetaArgs
                {
                    Name = "selfsigned-issuer",
                    Namespace = @namespace.Metadata.Apply(x => x.Name)
                },
                Spec = new ClusterIssuerSpecArgs
                {
                    SelfSigned = new ClusterIssuerSpecSelfsignedArgs()
                }
            },  new CustomResourceOptions { DependsOn = {crds, certManager}, DeletedWith = crds});

            var certificate = new Pulumi.Crds.Certmanager.V1.Certificate("certificate", new CertificateArgs
            {
                Metadata = new ObjectMetaArgs
                {
                    Name = "selfsigned-ca",
                    Namespace = @namespace.Metadata.Apply(x => x.Name)
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
        }
    }
}