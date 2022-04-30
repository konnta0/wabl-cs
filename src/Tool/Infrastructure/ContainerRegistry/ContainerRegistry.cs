using Infrastructure.CI_CD.Tekton;
using Microsoft.Extensions.Logging;
using Pulumi;

namespace Infrastructure.ContainerRegistry
{
    public class ContainerRegistry
    {
        private readonly ILogger<ContainerRegistry> _logger;
        private Config _config;
        private readonly Harbor.Harbor _harbor;

        public ContainerRegistry(ILogger<ContainerRegistry> logger, Config config, Harbor.Harbor harbor)
        {
            _logger = logger;
            _config = config;
            _harbor = harbor;
        }

        public void Apply()
        {
            _harbor.Apply();
        }
    }
}