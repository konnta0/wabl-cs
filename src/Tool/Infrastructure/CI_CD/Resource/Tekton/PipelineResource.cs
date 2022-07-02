using Pulumi;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.CI_CD.Resource.Tekton
{
    public class PipelineResource
    {
        private readonly Config _config;

        public PipelineResource(Config config)
        {
            _config = config;
        }

        public void Apply()
        {
            _ = new ConfigFile("tekton-controller-release", new ConfigFileArgs
            {
                File = "https://storage.googleapis.com/tekton-releases/pipeline/previous/v0.35.0/release.yaml"
            });
        }
    }
}