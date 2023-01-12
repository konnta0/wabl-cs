using Pulumi;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.CI_CD.Resource.Tekton
{
    public class ClusterRole
    {
        private readonly Config _config;

        public ClusterRole(Config config)
        {
            _config = config;
        }

        public void Apply()
        {
            _ = new ConfigFile("tekton-pipeline-cluster-role", new ConfigFileArgs
            {
                File = "./CI_CD/Resource/Tekton/Yaml/cluster-role.yaml"
            });
        }
    }
}