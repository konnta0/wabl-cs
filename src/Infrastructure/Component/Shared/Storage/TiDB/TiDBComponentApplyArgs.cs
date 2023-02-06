using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Component.Shared.Storage.TiDB
{
    public sealed class TiDBComponentInput : IComponentInput
    {
        public Namespace Namespace { get; set; }
    }

    public sealed class TiDBComponentOutput : IComponentOutput
    {
    }
}