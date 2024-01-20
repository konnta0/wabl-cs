using Infrastructure.Pulumi.Component.Shared.ContainerRegistry.Harbor;
using Infrastructure.Pulumi.Extension;
using Microsoft.Extensions.Logging;
using Pulumi;
using Pulumi.Crds.Certmanager.V1;
using Pulumi.Kubernetes.Types.Inputs.Certmanager.V1;
using Pulumi.Kubernetes.Types.Inputs.Meta.V1;

namespace Infrastructure.Pulumi.Component.Shared.ContainerRegistry
{
    public class ContainerRegistryComponent : IComponent<ContainerRegistryComponentInput, ContainerRegistryComponentOutput>
    {
        private readonly ILogger<ContainerRegistryComponent> _logger;
        private Config _config;
        private readonly HarborComponent _harborComponent;
        
        public ContainerRegistryComponent(ILogger<ContainerRegistryComponent> logger, Config config, HarborComponent harborComponent)
        {
            _logger = logger;
            _config = config;
            _harborComponent = harborComponent;
        }

        public ContainerRegistryComponentOutput Apply(ContainerRegistryComponentInput input)
        {
            var config = _config.GetContainerRegistryConfig();

            if (config.Harbor.Deploy)
            {
                var certificate = new global::Pulumi.Crds.Certmanager.V1.Certificate("container-registry-certificate",
                    new CertificateArgs
                    {
                        Metadata = new ObjectMetaArgs
                        {
                            Name = "selfsigned-ca-for-harbor",
                            Namespace = input.Namespace.Metadata.Apply(x => x.Name)
                        },
                        Spec = new CertificateSpecArgs
                        {
                            IsCA = true,
                            CommonName = "selfsigned-ca-for-harbor",
                            Duration = "438000h",
                            SecretName = "selfsigned-ca-cert",
                            PrivateKey = new CertificateSpecPrivatekeyArgs
                            {
                                Algorithm = "RSA",
                                Size = 2048
                            },
                            IssuerRef = new CertificateSpecIssuerrefArgs
                            {
                                Name = input.ClusterIssuer.Metadata.Apply(x => x.Name),
                                Kind = nameof(ClusterIssuer),
                                Group = "cert-manager.io"
                            },
                            DnsNames = { "cr.test", config.Host }
                        }
                    });

                var issuer = new Issuer("container-registry-issuer", new IssuerArgs
                {
                    Metadata = new ObjectMetaArgs
                    {
                        Name = "ca-issuer",
                        Namespace = input.Namespace.Metadata.Apply(x => x.Name)
                    },
                    Spec = new IssuerSpecArgs
                    {
                        Ca = new IssuerSpecCaArgs
                        {
                            SecretName = certificate.Spec.Apply(x => x.SecretName)
                        }
                    }
                });

                //var minioConsoleHost = _minIo.Apply(_namespaceName);
                var harborComponentOutput = _harborComponent.Apply(new HarborComponentInput
                {
                    Namespace = input.Namespace,
                    Issuer = issuer
                });
            
            }
            return new ContainerRegistryComponentOutput();
        }
    }
}