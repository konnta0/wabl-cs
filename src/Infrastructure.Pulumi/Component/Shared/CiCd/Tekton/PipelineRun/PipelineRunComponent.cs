using Pulumi;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.Pulumi.Component.Shared.CiCd.Tekton.PipelineRun
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
            if (!input.Deploy) return new PipelineRunComponentOutput();

            _ = new ConfigFile("tekton-pipeline-run-build-image", new ConfigFileArgs
            {
                File = "./Component/Shared/CiCd/Tekton/PipelineRun/Yaml/build-image.yaml"
            }, new ComponentResourceOptions { DependsOn = { input.TektonRelease, input.Namespace } });

            _ = new ConfigFile("tekton-pipeline-run-unit-test", new ConfigFileArgs
            {
                File = "./Component/Shared/CiCd/Tekton/PipelineRun/Yaml/unit-test.yaml"
            }, new ComponentResourceOptions { DependsOn = { input.TektonRelease, input.Namespace } });

            return new PipelineRunComponentOutput();
        }
    }
}