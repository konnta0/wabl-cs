using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Component.Shared.Storage.Redis
{
    public sealed class RedisComponentInput : IComponentInput
    {
        public Namespace Namespace { get; set; } = null!;
    }

    public sealed class RedisComponentOutput : IComponentOutput
    {
    }
}