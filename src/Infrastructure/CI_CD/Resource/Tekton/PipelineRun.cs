using System.Collections.Immutable;
using Pulumi;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.CI_CD.Resource.Tekton
{
    public class PipelineRun
    {
        private readonly Config _config;

        public PipelineRun(Config config)
        {
            _config = config;
        }

        public void Apply()
        {
            _ = new ConfigFile("tekton-pipeline-run-build-image", new ConfigFileArgs
            {
                File = "./CI_CD/Resource/Tekton/Yaml/PipelineRun/build-image.yaml",
                Transformations =
                {
                    TransformNamespace
                }
            });
            
            _ = new ConfigFile("tekton-pipeline-run-unit-test", new ConfigFileArgs
            {
                File = "./CI_CD/Resource/Tekton/Yaml/PipelineRun/unit-test.yaml",
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