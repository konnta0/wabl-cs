using System.Collections.Immutable;
using Pulumi;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.Component.Shared.CiCd.Tekton
{
    public class Pipeline
    {
        private readonly Config _config;

        public Pipeline(Config config)
        {
            _config = config;
        }

        public void Apply()
        {
            _ = new ConfigFile("tekton-pipeline-build-image", new ConfigFileArgs
            {
                File = "./Component/Shared/Tekton/Yaml/Pipeline/build-image.yaml",
                Transformations =
                {
                    TransformNamespace
                }
            });
            
            _ = new ConfigFile("tekton-pipeline-unit-test", new ConfigFileArgs
            {
                File = "./Component/Shared/Tekton/Yaml/Pipeline/unit-test.yaml",
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