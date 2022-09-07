using Pulumi;

namespace Infrastructure.WebApplication.Resource.Dotnet
{
    public class DotnetApplicationResource
    {
        private readonly Config _config;

        public DotnetApplicationResource(Config config)
        {
            _config = config;
        }

        public void Apply()
        {
            
        }
    }
}