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
            _ = new ConfigFile("tekton-pipeline-build-image", new ConfigFileArgs
            {
                File = "./Component/Shared/CiCd/Tekton/Pipeline/Yaml/build-image.yaml"
            }, new ComponentResourceOptions { DependsOn = { input.TektonRelease, input.Namespace } });

            _ = new ConfigFile("tekton-pipeline-unit-test", new ConfigFileArgs
            {
                File = "./Component/Shared/CiCd/Tekton/Pipeline/Yaml/unit-test.yaml"
            }, new ComponentResourceOptions { DependsOn = { input.TektonRelease, input.Namespace } });

            return new PipelineComponentOutput();
        }
    }
}