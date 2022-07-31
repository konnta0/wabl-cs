using Pulumi;

namespace Infrastructure.VersionControlSystem.Resource.GiLab
{
    public class GitLabResource
    {
        private readonly Config _config;

        public GitLabResource(Config config)
        {
            _config = config;
        }

        public void Apply()
        {
        }
    }
}