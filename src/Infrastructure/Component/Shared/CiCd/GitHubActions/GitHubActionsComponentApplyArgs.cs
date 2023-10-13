using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Component.Shared.CiCd.GitHubActions;

public sealed class GitHubActionsComponentInput : IComponentInput
{
    public Namespace Namespace { get; set; } = null!;
}

public sealed class GitHubActionsComponentOutput : IComponentOutput
{
}