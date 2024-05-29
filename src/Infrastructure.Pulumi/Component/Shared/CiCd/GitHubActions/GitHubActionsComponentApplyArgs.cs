using Pulumi;
using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Pulumi.Component.Shared.CiCd.GitHubActions;

public sealed class GitHubActionsComponentInput : IComponentInput
{
    public Namespace Namespace { get; init; } = null!;
    public string Version { get; init; } = "0.9.2";
}

public sealed class GitHubActionsComponentOutput : IComponentOutput
{
    public Output<string> RunnerSetName { get; set; } = null!;
}