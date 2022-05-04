using Infrastructure.CI_CD;
using Infrastructure.ContainerRegistry;
using Infrastructure.Extension;
using Infrastructure.Resource.Ingress;
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
            IngressResource ingressResource)
        {
            _logger = logger;
            _logger.LogInformation("start development stack");
            var isMinikube = config.IsMinikube();
            
            ingressResource.Apply();
            cicdComponent.Apply();
            containerRegistryComponent.Apply();
        }
    }
}