using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.Pulumi.Component.Shared.CiCd.Tekton.Task
{
    public sealed class TektonTaskComponentInput : IComponentInput
    {
        public required Namespace Namespace { get; set; }
        public required ConfigFile TektonRelease { get; set; }
    }

    public sealed class TektonTaskComponentOutput : IComponentOutput
    {
    }
}