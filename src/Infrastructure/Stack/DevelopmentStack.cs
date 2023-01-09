using Infrastructure.CI_CD;
using Infrastructure.Component.Shared.Certificate;
using Infrastructure.ContainerRegistry;
using Infrastructure.Resource.Shared.Certificate;
using Infrastructure.Resource.Shared.Observability;
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
            CICDComponent cicdComponent, 
            ContainerRegistryComponent containerRegistryComponent,
            ObservabilityComponent observabilityComponent,
            CertificateComponent certificateComponent,
            VersionControlSystemComponent versionControlSystemComponent,
            WebApplicationComponent webApplicationComponent)
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

            certificateComponent.Apply(@namespace);
            cicdComponent.Apply();
            (_, HarborExternalUrl) = containerRegistryComponent.Apply();
            GrafanaHost = observabilityComponent.Apply();
            //GitLabHost = versionControlSystemComponent.Apply();
            webApplicationComponent.Apply();
        }

        //[Output] public Output<string> GitLabHost { get; set; }
        // [Output] public Output<string> MinioConsoleHost { get; set; }
        [Output] public Output<string> HarborExternalUrl { get; set; }

        [Output] public Output<string> GrafanaHost { get; set; }
    }
}