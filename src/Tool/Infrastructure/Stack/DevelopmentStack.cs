using System.Collections.Immutable;
using Infrastructure.CI_CD;
using Infrastructure.ContainerRegistry;
using Infrastructure.Extension;
using Infrastructure.Observability;
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
            ObservabilityComponent observabilityComponent)
        {
            _logger = logger;
            _logger.LogInformation("start development stack");
            var isMinikube = config.IsMinikube();
            
            //ingressResource.Apply();
            cicdComponent.Apply();
            containerRegistryComponent.Apply();
            observabilityComponent.Apply();
            GrafanaNamespace = observabilityComponent.GrafanaNamespace;
            GrafanaResourceNames = observabilityComponent.ResourceNames;
        }

        [Output] public Output<string> GrafanaNamespace { get; set; }
        [Output] public Output<ImmutableDictionary<string, ImmutableArray<string>>> GrafanaResourceNames { get; set; }
    }
}