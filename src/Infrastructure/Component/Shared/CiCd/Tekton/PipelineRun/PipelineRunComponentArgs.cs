using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.Component.Shared.CiCd.Tekton.PipelineRun
{
    public sealed class PipelineRunComponentInput : IComponentInput
    {
        public ConfigFile TektonRelease { get; set; }
    }

    public sealed class PipelineRunComponentOutput : IComponentOutput
    {
    }
}