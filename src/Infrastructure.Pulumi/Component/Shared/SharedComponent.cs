using System.Text.Json;
using Infrastructure.Pulumi.Component.Shared.Certificate;
using Infrastructure.Pulumi.Component.Shared.CiCd;
using Infrastructure.Pulumi.Component.Shared.ContainerRegistry;
using Infrastructure.Pulumi.Component.Shared.Identity;
using Infrastructure.Pulumi.Component.Shared.Observability;
using Infrastructure.Pulumi.Component.Shared.Storage;
using Pulumi;
using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Types.Inputs.Core.V1;
using Pulumi.Kubernetes.Types.Inputs.Meta.V1;

namespace Infrastructure.Pulumi.Component.Shared
{
    public class SharedComponent : IComponent<SharedComponentInput, SharedComponentOutput>
    {
        private readonly Config _config;
        private readonly StorageComponent _storageComponent;
        private readonly CertificateComponent _certificateComponent;
        private readonly CiCdComponent _ciCdComponent;
        private readonly ContainerRegistryComponent _containerRegistryComponent;
        private readonly ObservabilityComponent _observabilityComponent;
        private readonly IdentityComponent _identityComponent;

        public SharedComponent(
            Config config, 
            StorageComponent storageComponent,
            CertificateComponent certificateComponent,
            CiCdComponent ciCdComponent,
            ContainerRegistryComponent containerRegistryComponent,
            ObservabilityComponent observabilityComponent,
            IdentityComponent identityComponent
            )
        {
            _config = config;
            _storageComponent = storageComponent;
            _certificateComponent = certificateComponent;
            _ciCdComponent = ciCdComponent;
            _containerRegistryComponent = containerRegistryComponent;
            _observabilityComponent = observabilityComponent;
            _identityComponent = identityComponent;
        }
        
        public SharedComponentOutput Apply(SharedComponentInput input)
        {
            var @namespace = new Namespace("namespace-shared-resource", new NamespaceArgs
            {
                Metadata = new ObjectMetaArgs
                {
                    Name = "shared"
                }
            });

            var storageComponentOutput = _storageComponent.Apply(new StorageComponentInput { Namespace = @namespace });
            var certificateComponentOutput =
                _certificateComponent.Apply(new CertificateComponentInput { Namespace = @namespace });
            _ciCdComponent.Apply(new CiCdComponentInput
            {
                Namespace = @namespace
            });
            var containerRegistryComponentOutput = _containerRegistryComponent.Apply(new ContainerRegistryComponentInput
            {
                Namespace = @namespace,
                ClusterIssuer = certificateComponentOutput.ClusterIssuer
            });

            if (_config.RequireObject<JsonElement>("Observability").GetProperty("Enable").GetBoolean())
            {
                _observabilityComponent.Apply(new ObservabilityComponentInput
                {
                    Namespace = @namespace,
                    MinioRelease = storageComponentOutput.MinIoRelease
                });
            }
            
            _identityComponent.Apply(new IdentityComponentInput
            {
                Namespace = @namespace
            });
            
            return new SharedComponentOutput
            {
                Namespace = @namespace
            };
        }
    }
}