using System.Collections.Immutable;
using Pulumi;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.Component.Shared.CiCd.Tekton.PipelineRun
{
    public class PipelineRunComponent : IComponent<PipelineRunComponentInput, PipelineRunComponentOutput>
    {
        private readonly Config _config;

        public PipelineRunComponent(Config config)
        {
            _config = config;
        }
        
        public PipelineRunComponentOutput Apply(PipelineRunComponentInput input)
        {
            var ns = input.Namespace.Metadata.Apply(x => x.Name);
            ImmutableDictionary<string, object> TransformNamespace(ImmutableDictionary<string, object> obj,
                CustomResourceOptions opts)
            {
                var metadata = (ImmutableDictionary<string, object>)obj["metadata"];
                if (!metadata.ContainsKey("namespace")) return obj;
                return obj.SetItem("metadata", metadata.SetItem("namespace", ns));
            }

            _ = new ConfigFile("tekton-pipeline-run-build-image", new ConfigFileArgs
            {
                File = "./Component/Shared/CiCd/Tekton/PipelineRun/Yaml/build-image.yaml",
                Transformations =
                {
                    TransformNamespace
                }
            }, new ComponentResourceOptions { DependsOn = { input.Namespace } });

            _ = new ConfigFile("tekton-pipeline-run-unit-test", new ConfigFileArgs
            {
                File = "./Component/Shared/CiCd/Tekton/PipelineRun/Yaml/unit-test.yaml",
                Transformations =
                {
                    TransformNamespace
                }
            }, new ComponentResourceOptions { DependsOn = { input.Namespace } });

        return new PipelineRunComponentOutput();
        }
    }
}