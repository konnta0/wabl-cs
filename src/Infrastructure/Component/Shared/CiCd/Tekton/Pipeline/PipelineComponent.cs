using System.Collections.Immutable;
using Pulumi;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.Component.Shared.CiCd.Tekton.Pipeline
{
    public class PipelineComponent : IComponent<PipelineComponentInput, PipelineComponentOutput>
    {
        private readonly Config _config;

        public PipelineComponent(Config config)
        {
            _config = config;
        }
        
        public PipelineComponentOutput Apply(PipelineComponentInput input)
        {
            var ns = input.Namespace.Metadata.Apply(x => x.Name);
            ImmutableDictionary<string, object> TransformNamespace(ImmutableDictionary<string, object> obj, CustomResourceOptions opts)
            {
                var metadata = (ImmutableDictionary<string, object>)obj["metadata"];
                if (!metadata.ContainsKey("namespace")) return obj;
                return obj.SetItem("metadata", metadata.SetItem("namespace", ns));
            }

            _ = new ConfigFile("tekton-pipeline-build-image", new ConfigFileArgs
            {
                File = "./Component/Shared/CiCd/Tekton/Pipeline/Yaml/build-image.yaml",
                Transformations =
                {
                    TransformNamespace
                }
            }, new ComponentResourceOptions {DependsOn = {input.Namespace}});
            
            _ = new ConfigFile("tekton-pipeline-unit-test", new ConfigFileArgs
            {
                File = "./Component/Shared/CiCd/Tekton/Pipeline/Yaml/unit-test.yaml",
                Transformations =
                {
                    TransformNamespace
                }
            }, new ComponentResourceOptions {DependsOn = {input.Namespace}});

            return new PipelineComponentOutput();
        }
    }
}