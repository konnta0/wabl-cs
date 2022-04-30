using Infrastructure.CI_CD;
using Infrastructure.ContainerRegistry.Component;
using Infrastructure.Extension;
using Microsoft.Extensions.Logging;
using Pulumi;


namespace Infrastructure.Stack
{
    public class DevelopmentStack : Pulumi.Stack
    {
        private readonly ILogger<DevelopmentStack> _logger;

        public DevelopmentStack(ILogger<DevelopmentStack> logger, Config config, CICD cicd, Harbor harbor)
        {
            _logger = logger;
            _logger.LogInformation("start development stack");
            var isMinikube = config.IsMinikube();
            
            cicd.Apply();
            harbor.Apply();
        }
    }
}