using System.Collections.Immutable;
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
            _ = new ConfigFile("tekton-pipeline-resource-container-image-config", new ConfigFileArgs
            {
                File = "./CI_CD/Resource/Tekton/Yaml/PipelineResource/ContainerImage.yaml",
                Transformations =
                {
                    TransformNamespace
                }
            });
            
            _ = new ConfigFile("tekton-pipeline-resource-source-code-github-config", new ConfigFileArgs
            {
                File = "./CI_CD/Resource/Tekton/Yaml/PipelineResource/SourceCodeGithub.yaml",
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