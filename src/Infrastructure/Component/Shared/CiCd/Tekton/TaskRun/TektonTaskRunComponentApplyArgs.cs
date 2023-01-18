using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.Component.Shared.CiCd.Tekton.TaskRun
{
    public sealed class TektonTaskRunComponentInput : IComponentInput
    {
        public ConfigFile TektonRelease { get; set; }
    }

    public sealed class TektonTaskRunComponentOutput : IComponentOutput
    {
    }
}