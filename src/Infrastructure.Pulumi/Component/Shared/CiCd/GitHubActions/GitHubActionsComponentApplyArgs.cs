using Pulumi;
using Pulumi.Kubernetes.Core.V1;

namespace Infrastructure.Pulumi.Component.Shared.CiCd.GitHubActions;

public sealed class GitHubActionsComponentInput : IComponentInput
{
    public Namespace Namespace { get; set; } = null!;
    public string Version { get; set; } = "0.6.1";
    public bool WithActContainer { get; set; } = false;
}

public sealed class GitHubActionsComponentOutput : IComponentOutput
{
    public Output<string> RunnerSetName { get; set; } = null!;
}