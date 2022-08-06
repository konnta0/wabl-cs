using System.Collections.Immutable;
using Infrastructure.Certificate;
using Infrastructure.CI_CD;
using Infrastructure.ContainerRegistry;
using Infrastructure.Extension;
using Infrastructure.Observability;
using Infrastructure.VersionControlSystem;
using Microsoft.Extensions.Logging;
using Pulumi;


namespace Infrastructure.Stack
{
    public class DevelopmentStack : Pulumi.Stack
    {
        private readonly ILogger<DevelopmentStack> _logger;

        public DevelopmentStack(ILogger<DevelopmentStack> logger, Config config, 
            CICDComponent cicdComponent, 
            ContainerRegistryComponent containerRegistryComponent,
            ObservabilityComponent observabilityComponent,
            CertificateComponent certificateComponent,
            VersionControlSystemComponent versionControlSystemComponent)
        {
            _logger = logger;
            _logger.LogInformation("start development stack");
            var isMinikube = config.IsMinikube();
            
            certificateComponent.Apply();
            cicdComponent.Apply();
            containerRegistryComponent.Apply();
            observabilityComponent.Apply();
            HarborExternalUrl = containerRegistryComponent.HarborExternalUrl;
            GrafanaHost = observabilityComponent.GrafanaHost;
            certificateComponent.Apply();
        }

        [Output] public Output<string> HarborExternalUrl { get; set; }

        [Output] public Output<string> GrafanaHost { get; set; }
    }
}