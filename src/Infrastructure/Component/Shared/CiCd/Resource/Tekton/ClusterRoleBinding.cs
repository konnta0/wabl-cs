using System.Collections.Immutable;
using Pulumi;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.CI_CD.Resource.Tekton
{
    public class ClusterRoleBinding
    {
        private readonly Config _config;

        public ClusterRoleBinding(Config config)
        {
            _config = config;
        }

        public void Apply()
        {
            _ = new ConfigFile("tekton-pipeline-cluster-role-binding", new ConfigFileArgs
            {
                File = "./CI_CD/Resource/Tekton/Yaml/cluster-role-binding.yaml",
                Transformations =
                {
                    TransformNamespace
                }
            });
        }
        
        private ImmutableDictionary<string, object> TransformNamespace(ImmutableDictionary<string, object> obj, CustomResourceOptions opts)
        {
            var metadata = (ImmutableDictionary<string, object>)obj["metadata"];
            if (!metadata.ContainsKey("namespace")) return obj;
            return obj.SetItem("metadata", metadata.SetItem("namespace", "tekton-pipelines"));
        }
    }
}