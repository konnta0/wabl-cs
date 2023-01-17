using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.Component.Shared.CiCd.Tekton.Task
{
    public sealed class TektonTaskComponentInput : IComponentInput
    {
        public ConfigFile TektonRelease { get; set; }
    }

    public sealed class TektonTaskComponentOutput : IComponentOutput
    {
    }
}