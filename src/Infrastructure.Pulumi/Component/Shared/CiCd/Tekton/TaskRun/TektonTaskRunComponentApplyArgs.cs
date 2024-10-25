using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.Pulumi.Component.Shared.CiCd.Tekton.TaskRun
{
    public sealed class TektonTaskRunComponentInput : IComponentInput
    {
        public required Namespace Namespace { get; set; }
        public required ConfigFile TektonRelease { get; set; }
    }

    public sealed class TektonTaskRunComponentOutput : IComponentOutput
    {
    }
}