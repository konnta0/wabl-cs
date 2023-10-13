using System.Collections.Generic;
using Pulumi.Kubernetes.Helm.V3;
using Pulumi.Kubernetes.Types.Inputs.Helm.V3;

namespace Infrastructure.Component.Shared.CiCd.GitHubActions;

public sealed class GitHubActionsComponent : IComponent<GitHubActionsComponentInput, GitHubActionsComponentOutput>
{
    public GitHubActionsComponentOutput Apply(GitHubActionsComponentInput input)
    {
        var values = new Dictionary<string, object>
        {
            ["githubConfigUrl"] = "https://github.com/konnta0/wabl-cs",
            ["githubConfigSecret"] = new Dictionary<string, object>
            {
                ["github_token"] = ""
            }
        };
        var release = new Release("gha-runner-scale-set-controller", new ReleaseArgs
        {
            Name = "arc-runner-set",
            Chart = "oci://ghcr.io/actions/actions-runner-controller-charts/gha-runner-scale-set-controller",
            Namespace = input.Namespace.Metadata.Apply(static x => x.Name),
            Values = values,
            RecreatePods = true
        });
        return new GitHubActionsComponentOutput();
    }
}
