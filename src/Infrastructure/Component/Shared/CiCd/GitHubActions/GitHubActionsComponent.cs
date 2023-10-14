using System.Collections.Generic;
using Pulumi;
using Pulumi.Kubernetes.Helm.V3;
using Pulumi.Kubernetes.Types.Inputs.Helm.V3;

namespace Infrastructure.Component.Shared.CiCd.GitHubActions;

public sealed class GitHubActionsComponent : IComponent<GitHubActionsComponentInput, GitHubActionsComponentOutput>
{
    public GitHubActionsComponentOutput Apply(GitHubActionsComponentInput input)
    {
        var controller = new Release("gha-runner-scale-set-controller", new ReleaseArgs
        {
            Name = "gha-runner-scale-set-controller",
            Version = input.Version,
            Chart = "oci://ghcr.io/actions/actions-runner-controller-charts/gha-runner-scale-set-controller",
            Namespace = input.Namespace.Metadata.Apply(static x => x.Name),
            RecreatePods = true
        });


        // https://github.com/actions/actions-runner-controller/blob/gha-runner-scale-set-0.6.1/charts/gha-runner-scale-set/values.yaml
        var values = new InputMap<object>
        {
            ["githubConfigUrl"] = "https://github.com/konnta0/wabl-cs",
            ["githubConfigSecret"] = new Dictionary<string, object>
            {
                ["github_token"] = ""
            },
            ["controllerServiceAccount"] = new Dictionary<string, object>
            {
                ["namespace"] = input.Namespace.Metadata.Apply(static x => x.Name),
                ["name"] = controller.Name.Apply(static x => x + "-gha-rs-controller")
            }
        };
        var scaleSet = new Release("gha-runner-scale-set", new ReleaseArgs
        {
            Name = "arc-runner-set",
            Version = input.Version,
            Chart = "oci://ghcr.io/actions/actions-runner-controller-charts/gha-runner-scale-set",
            Values = values,
            Namespace = input.Namespace.Metadata.Apply(static x => x.Name),
            RecreatePods = true
        }, new CustomResourceOptions
        {
            DependsOn = controller
        });

        return new GitHubActionsComponentOutput
        {
            RunnerSetName = scaleSet.Name
        };
    }
}
