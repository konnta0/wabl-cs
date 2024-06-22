using System.Collections.Generic;
using System.Text.Json;
using Pulumi;
using Pulumi.Kubernetes.Helm.V3;
using Pulumi.Kubernetes.Types.Inputs.Helm.V3;

namespace Infrastructure.Pulumi.Component.Shared.CiCd.GitHubActions;

public sealed class GitHubActionsComponent(Config config)
    : IComponent<GitHubActionsComponentInput, GitHubActionsComponentOutput>
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


        // https://github.com/actions/actions-runner-controller/blob/gha-runner-scale-set-0.8.3/charts/gha-runner-scale-set/values.yaml
        var ciCdConfig = config.RequireObject<JsonElement>("CiCd");

        var githubToken = ciCdConfig.GetProperty("Gha").GetProperty("Pat").GetString();
        var values = new InputMap<object>
        {
            ["githubConfigUrl"] = "https://github.com/konnta0/wabl-cs",
            ["githubConfigSecret"] = new Dictionary<string, object>
            {
                ["github_token"] = githubToken!
            },
            ["containerMode"] = new Dictionary<string, object>
            {
                ["type"] = "" // https://github.com/actions/actions-runner-controller/blob/gha-runner-scale-set-0.8.3/charts/gha-runner-scale-set/values.yaml#L76-L77
            },
            // for kubernetes mode
            // ["kubernetesModeWorkVolumeClaim"] = new Dictionary<string, object>
            // {
            //     ["accessModes"] = new List<string> { "ReadWriteOnce" },
            //     ["storageClassName"] = "dynamic-blob-storage",
            //     ["resources"] = new Dictionary<string, object>
            //     {
            //         ["requests"] = new Dictionary<string, object>
            //         {
            //             ["storage"] = "1Gi"
            //         }
            //     }
            // },
            ["controllerServiceAccount"] = new Dictionary<string, object>
            {
                ["namespace"] = input.Namespace.Metadata.Apply(static x => x.Name),
                ["name"] = controller.Name.Apply(static x => x + "-gha-rs-controller")
            },
            ["minRunners"] = 1,
            // for kubernetes mode
            // ["template"] = new InputMap<object>
            // {
            //     ["spec"] = new InputMap<object>
            //     {
            //         { 
            //             "containers", new InputList<InputMap<object>>
            //             {
            //                 new InputMap<object>
            //                 {
            //                     { "name", "runner" },
            //                     { "image", "ghcr.io/actions/actions-runner:latest" },
            //                     {
            //                         "command",
            //                         new InputList<string>
            //                             { "/home/runner/run.sh" }
            //                     },
            //                     {
            //                         "env", new InputList<InputMap<object>>
            //                         {
            //                             new InputMap<object>
            //                             {
            //                                 { "name", "ACTIONS_RUNNER_CONTAINER_HOOKS" },
            //                                 { "value", "/home/runner/k8s/index.js" },
            //                             },
            //                             new InputMap<object>
            //                             {
            //                                 { "name", "ACTIONS_RUNNER_POD_NAME" },
            //                                 { 
            //                                     "valueFrom", new InputMap<object>
            //                                     {
            //                                         { "fieldRef", new InputMap<object>
            //                                             {
            //                                                 { "fieldPath", "metadata.name" } 
            //                                                 
            //                                             }
            //                                         }
            //                                     }
            //                                 }
            //                             },
            //                             new InputMap<object>
            //                             {
            //                                 { "name", "ACTIONS_RUNNER_REQUIRE_JOB_CONTAINER" },
            //                                 { "value", "false"}
            //                             }
            //                         }
            //                     },
            //                     {
            //                         "volumeMounts", new InputList<InputMap<object>>
            //                         {
            //                             new InputMap<object>
            //                             {
            //                                 { "name", "work" },
            //                                 { "mountPath", "/home/runner/_work" }
            //                             }
            //                         }
            //                     }
            //                 }
            //             }
            //         },
            //         {
            //             "volumes", new InputList<InputMap<object>>
            //             {
            //                 new InputMap<object>
            //                 {
            //                     { "name", "work" },
            //                     {
            //                         "ephemeral", new InputMap<object>
            //                         {
            //                             {
            //                                 "volumeClaimTemplate", new InputMap<object>
            //                                 {
            //                                     {
            //                                         "spec", new InputMap<object>
            //                                         {
            //                                             { "accessModes", new List<string> { "ReadWriteOnce" } },
            //                                             { "storageClassName", "local-path" },
            //                                             {
            //                                                 "resources", new InputMap<object>
            //                                                 {
            //                                                     {
            //                                                         "requests", new InputMap<object>
            //                                                         {
            //                                                             { "storage", "1Gi" }
            //                                                         }
            //                                                     }
            //                                                 }
            //                                             }
            //                                         }
            //                                     }
            //                                 }
            //                             }
            //                         }
            //                     }
            //                 }
            //             }
            //         }
            //     }
            // }
            // for DinD mode
            ["template"] = new InputMap<object>
            {
                ["spec"] = new InputMap<object>
                {
                    {
                        "initContainers", new InputList<InputMap<object>>
                        {
                            new InputMap<object>
                            {
                                { "name", "init-dind-externals" },
                                { "image", "ghcr.io/actions/actions-runner:latest" },
                                {
                                    "command",
                                    new InputList<string>
                                        { "cp", "-r", "-v", "/home/runner/externals/.", "/home/runner/tmpDir/" }
                                },
                                {
                                    "volumeMounts", new InputList<InputMap<object>>
                                    {
                                        new InputMap<object>
                                        {
                                            { "name", "dind-externals" },
                                            { "mountPath", "/home/runner/tmpDir" }
                                        }
                                    }
                                }
                            }
                        }
                    },
                    {
                        "containers", new InputList<InputMap<object>>
                        {
                            new InputMap<object>
                            {
                                { "name", "runner" },
                                { "image", "ghcr.io/actions/actions-runner:latest" },
                                { "command", new InputList<string> { "/home/runner/run.sh" }  },
                                {
                                    "env", new InputList<InputMap<object>>
                                    {
                                        new InputMap<object>
                                        {
                                            { "name", "DOCKER_HOST" },
                                            { "value", "unix:///run/docker/docker.sock" }
                                        }
                                    }
                                },
                                {
                                    "volumeMounts", new InputList<InputMap<object>>
                                    {
                                        new InputMap<object>
                                        {
                                            { "name", "work" },
                                            { "mountPath", "/home/runner/_work" }
                                        },
                                        new InputMap<object>
                                        {
                                            { "name", "dind-sock" },
                                            { "mountPath", "/run/docker" },
                                            { "readOnly", true }
                                        }
                                    }
                                }
                            },
                            new InputMap<object>
                            {
                                { "name", "dind" },
                                { "image", "docker:dind" },
                                {
                                    "args", new InputList<string>
                                    {
                                        "dockerd",
                                        "--host=unix:///run/docker/docker.sock",
                                        "--group=$(DOCKER_GROUP_GID)",
                                        "--mtu=$(DOCKERD_ROOTLESS_ROOTLESSKIT_MTU)"
                                    }
                                },
                                {
                                    "env", new InputList<InputMap<object>>
                                    {
                                        new InputMap<object>
                                        {
                                            { "name", "DOCKERD_ROOTLESS_ROOTLESSKIT_MTU" },
                                            { "value", "1450" },
                                        },
                                        new InputMap<object>
                                        {
                                            { "name", "DOCKER_GROUP_GID" },
                                            { "value", "123" },
                                        }
                                    }
                                },
                                {
                                    "securityContext", new InputMap<object>
                                    {
                                        { "privileged", true }
                                    }
                                },
                                {
                                    "volumeMounts", new InputList<InputMap<object>>
                                    {
                                        new InputMap<object>
                                        {
                                            { "name", "work" },
                                            { "mountPath", "/home/runner/_work" }
                                        },
                                        new InputMap<object>
                                        {
                                            { "name", "dind-sock" },
                                            { "mountPath", "/run/docker" }
                                        },
                                        new InputMap<object>
                                        {
                                            { "name", "dind-externals" },
                                            { "mountPath", "/home/runner/externals" }
                                        },
                                    }
                                }
                            }
                        }
                    },
                    {
                        "volumes", new InputList<InputMap<object>>
                        {
                            new InputMap<object>
                            {
                                { "name", "work" },
                                { "emptyDir", new Dictionary<string, string>() }
                            },
                            new InputMap<object>
                            {
                                { "name", "dind-sock" },
                                { "emptyDir", new Dictionary<string, string>() }
                            },
                            new InputMap<object>
                            {
                                { "name", "dind-externals" },
                                { "emptyDir", new Dictionary<string, string>() }
                            }
                        }
                    }
                }
            }
        };
        
        var runnerName = ciCdConfig.GetProperty("Runner").GetProperty("Name").GetString()!;
        var scaleSet = new Release("gha-runner-scale-set", new ReleaseArgs
        {
            Name = runnerName,
            Version = input.Version,
            Chart = "oci://ghcr.io/actions/actions-runner-controller-charts/gha-runner-scale-set",
            Values = values,
            Namespace = input.Namespace.Metadata.Apply(static x => x.Name),
            RecreatePods = true,
            Atomic = true,
            Replace = true
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
