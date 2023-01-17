using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.Component.Shared.CiCd.Tekton.Pipeline
{
    public sealed class PipelineComponentInput : IComponentInput
    {
        public ConfigFile TektonRelease { get; set; }
    }

    public sealed class PipelineComponentOutput : IComponentOutput
    {
    }
}