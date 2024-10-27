using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Pulumi.Component.Shared.Storage.Redis
{
    public sealed class RedisComponentInput : IComponentInput
    {
        public required Namespace Namespace { get; init; }
    }

    public sealed class RedisComponentOutput : IComponentOutput
    {
    }
}