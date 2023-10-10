using System.Text.Json;
using Infrastructure.Component.Shared;
using Infrastructure.Component.Shared.Certificate;
using Infrastructure.Component.Shared.CiCd;
using Infrastructure.Component.Shared.ContainerRegistry;
using Infrastructure.Component.Shared.Observability;
using Infrastructure.Component.Shared.Storage;
using Infrastructure.Component.Tool;
using Infrastructure.Component.WebApplication;
using Microsoft.Extensions.Logging;
using Pulumi;
using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Types.Inputs.Core.V1;
using Pulumi.Kubernetes.Types.Inputs.Meta.V1;


namespace Infrastructure.Stack
{
    public class LocalStack : Pulumi.Stack
    {
        private readonly ILogger<LocalStack> _logger;
        private readonly Config _config;
        private readonly ToolComponent _toolComponent;

        public LocalStack(ILogger<LocalStack> logger, Config config, 
            CiCdComponent ciCdComponent, 
            ContainerRegistryComponent containerRegistryComponent,
            ObservabilityComponent observabilityComponent,
            CertificateComponent certificateComponent,
            WebApplicationComponent webApplicationComponent,
            StorageComponent storageComponent,
            SharedComponent sharedComponent,
            ToolComponent toolComponent)
        {
            _logger = logger;
            _config = config;
            _toolComponent = toolComponent;
            _logger.LogInformation("start development stack");
            sharedComponent.Apply(new SharedComponentInput());
            
            
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

            if (_config.RequireObject<JsonElement>("Observability").GetProperty("Enable").GetBoolean())
            {
                observabilityComponent.Apply(new ObservabilityComponentInput
                {
                    Namespace = @namespace
                });
            }
            //GitLabHost = versionControlSystemComponent.Apply();
            webApplicationComponent.Apply(new WebApplicationComponentInput
            {
                
            });

            toolComponent.Apply(new ToolComponentInput
            {
                
            });
        }

    }
}