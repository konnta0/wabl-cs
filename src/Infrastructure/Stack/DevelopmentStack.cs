using Infrastructure.Component.Shared.Certificate;
using Infrastructure.Component.Shared.CiCd;
using Infrastructure.Component.Shared.ContainerRegistry;
using Infrastructure.Component.Shared.Observability;
using Infrastructure.Component.Shared.Storage;
using Infrastructure.VersionControlSystem;
using Infrastructure.WebApplication;
using Microsoft.Extensions.Logging;
using Pulumi;
using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Types.Inputs.Core.V1;
using Pulumi.Kubernetes.Types.Inputs.Meta.V1;


namespace Infrastructure.Stack
{
    public class DevelopmentStack : Pulumi.Stack
    {
        private readonly ILogger<DevelopmentStack> _logger;
        private readonly Config _config;

        public DevelopmentStack(ILogger<DevelopmentStack> logger, Config config, 
            CiCdComponent ciCdComponent, 
            ContainerRegistryComponent containerRegistryComponent,
            ObservabilityComponent observabilityComponent,
            CertificateComponent certificateComponent,
            VersionControlSystemComponent versionControlSystemComponent,
            WebApplicationComponent webApplicationComponent,
            StorageComponent storageComponent)
        {
            _logger = logger;
            _config = config;
            _logger.LogInformation("start development stack");
            var @namespace = new Namespace("namespace-shared-resource", new NamespaceArgs
            {
                Metadata = new ObjectMetaArgs
                {
                    Name = "shared"
                }
            });

            var storageComponentOutput = storageComponent.Apply(new StorageComponentInput { Namespace = @namespace });
            var certificateComponentOutput =
                certificateComponent.Apply(new CertificateComponentInput { Namespace = @namespace });
            ciCdComponent.Apply(new CiCdComponentInput
            {
                Namespace = @namespace
            });
            var containerRegistryComponentOutput = containerRegistryComponent.Apply(new ContainerRegistryComponentInput
            {
                Namespace = @namespace,
                ClusterIssuer = certificateComponentOutput.ClusterIssuer
            });
            observabilityComponent.Apply(new ObservabilityComponentInput
            {
                Namespace = @namespace
            });
            //GitLabHost = versionControlSystemComponent.Apply();
            webApplicationComponent.Apply();
        }

    }
}