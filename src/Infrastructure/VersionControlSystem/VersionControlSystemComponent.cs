using Infrastructure.VersionControlSystem.Resource.GiLab;
using Microsoft.Extensions.Logging;
using Pulumi;

namespace Infrastructure.VersionControlSystem
{
    public class VersionControlSystemComponent
    {
        private Config _config;
        private readonly GitLabResource _gitLabResource;
        private readonly ILogger<VersionControlSystemComponent> _logger;

        public VersionControlSystemComponent(ILogger<VersionControlSystemComponent> logger, Config config, GitLabResource gitLabResource)
        {
            _logger = logger;
            _config = config;
            _gitLabResource = gitLabResource;
        }

        public void Apply()
        {
            _gitLabResource.Apply();
        }
    }
}