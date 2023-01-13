using Infrastructure.Component.Shared.ContainerRegistry.Harbor;
using Infrastructure.Component.Shared.ContainerRegistry.Resource;
using Microsoft.Extensions.Logging;
using Pulumi;
using Pulumi.Crds.Certmanager.V1;
using Pulumi.Kubernetes.Types.Inputs.Certmanager.V1;
using Pulumi.Kubernetes.Types.Inputs.Meta.V1;

namespace Infrastructure.Component.Shared.ContainerRegistry
{
    public class ContainerRegistryComponent : IComponent<ContainerRegistryComponentInput, ContainerRegistryComponentOutput>
    {
        private readonly ILogger<ContainerRegistryComponent> _logger;
        private Config _config;
        private readonly HarborComponent _harborComponent;
        private readonly MinIO _minIo;
        
        public ContainerRegistryComponent(ILogger<ContainerRegistryComponent> logger, Config config, HarborComponent harborComponent, MinIO minIo)
        {
            _logger = logger;
            _config = config;
            _harborComponent = harborComponent;
            _minIo = minIo;
        }

        public ContainerRegistryComponentOutput Apply(ContainerRegistryComponentInput input)
        {
            var certificate = new Pulumi.Crds.Certmanager.V1.Certificate("container-registry-certificate",
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
                            Group = "cert-manager.io"
                        }
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
            return new ContainerRegistryComponentOutput();
        }
    }
}