using Infrastructure.ContainerRegistry.Component;
using Microsoft.Extensions.Logging;
using Pulumi;
using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Types.Inputs.Core.V1;
using Pulumi.Kubernetes.Types.Inputs.Meta.V1;

namespace Infrastructure.ContainerRegistry
{
    public class ContainerRegistryComponent
    {
        private readonly ILogger<ContainerRegistryComponent> _logger;
        private Config _config;
        private readonly Harbor _harbor;
        private readonly MinIO _minIo;

        public ContainerRegistryComponent(ILogger<ContainerRegistryComponent> logger, Config config, Harbor harbor, MinIO minIo)
        {
            _logger = logger;
            _config = config;
            _harbor = harbor;
            _minIo = minIo;
        }

        public void Apply()
        {
            var @namespace = new Namespace("namespace-container-registry", new NamespaceArgs
            {
                Metadata = new ObjectMetaArgs
                {
                    Name = Define.Namespace
                }
            });
            _minIo.Apply(@namespace.Metadata.Apply(x => x.Name));
            _harbor.Apply(@namespace.Metadata.Apply(x => x.Name));
            HarborExternalUrl = _harbor.HarborExternalUrl;
        }

        [Output] public Output<string> HarborExternalUrl { get; set; }
    }
}