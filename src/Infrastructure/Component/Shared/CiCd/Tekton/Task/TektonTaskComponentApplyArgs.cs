using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.Component.Shared.CiCd.Tekton.Task
{
    public sealed class TektonTaskComponentInput : IComponentInput
    {
        public Namespace Namespace { get; set; } = null!;
        public ConfigFile TektonRelease { get; set; } = null!;
    }

    public sealed class TektonTaskComponentOutput : IComponentOutput
    {
    }
}