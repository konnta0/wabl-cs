using System.Collections.Immutable;
using Infrastructure.Component.Shared.ContainerRegistry.Harbor;
using Infrastructure.Component.Shared.ContainerRegistry.Resource;
using Infrastructure.Extension;
using Microsoft.Extensions.Logging;
using Pulumi;
using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Types.Inputs.Core.V1;
using Pulumi.Kubernetes.Types.Inputs.Meta.V1;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.Component.Shared.ContainerRegistry
{
    public class ContainerRegistryComponent
    {
        private readonly ILogger<ContainerRegistryComponent> _logger;
        private Config _config;
        private readonly HarborComponent _harborComponent;
        private readonly MinIO _minIo;
        private Input<string> _namespaceName;
        
        public ContainerRegistryComponent(ILogger<ContainerRegistryComponent> logger, Config config, HarborComponent harborComponent, MinIO minIo)
        {
            _logger = logger;
            _config = config;
            _harborComponent = harborComponent;
            _minIo = minIo;
        }

        public (string minioConsoleHost, Output<string> harborExternalUrl) Apply()
        {
            var @namespace = new Namespace("namespace-container-registry", new NamespaceArgs
            {
                Metadata = new ObjectMetaArgs
                {
                    Name = _config.GetContainerRegistryConfig().Namespace
                }
            });
            _namespaceName = @namespace.Metadata.Apply(x => x.Name);

            _ = new ConfigFile("container-registry-certificate", new ConfigFileArgs
            {
                File = "Resource/Shared/Certificate/Yaml/certificate.yaml",
                Transformations =
                {
                    TransformNamespace
                }
            });

            _ = new ConfigFile("container-registry-issuer", new ConfigFileArgs
            {
                File = "Resource/Shared/Certificate/Yaml/issuer.yaml",
                Transformations =
                {
                    TransformNamespace
                }
            });

            //var minioConsoleHost = _minIo.Apply(_namespaceName);
            var harborExternalUrl = _harborComponent.Apply(_namespaceName);

            return (string.Empty, harborExternalUrl);
        }

        private ImmutableDictionary<string, object> TransformNamespace(ImmutableDictionary<string, object> obj, CustomResourceOptions opts)
        {
            var metadata = (ImmutableDictionary<string, object>)obj["metadata"];
            if (!metadata.ContainsKey("namespace")) return obj;
            return obj.SetItem("metadata", metadata.SetItem("namespace", _namespaceName));
        }
    }
}