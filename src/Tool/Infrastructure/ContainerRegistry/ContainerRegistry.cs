using Infrastructure.ContainerRegistry.Component;
using Microsoft.Extensions.Logging;
using Pulumi;

namespace Infrastructure.ContainerRegistry
{
    public class ContainerRegistry
    {
        private readonly ILogger<ContainerRegistry> _logger;
        private Config _config;
        private readonly Harbor _harbor;
        private readonly MinIO _minIo;

        public ContainerRegistry(ILogger<ContainerRegistry> logger, Config config, Harbor harbor, MinIO minIo)
        {
            _logger = logger;
            _config = config;
            _harbor = harbor;
            _minIo = minIo;
        }

        public void Apply()
        {
            _minIo.Apply();
            _harbor.Apply();
        }
    }
}