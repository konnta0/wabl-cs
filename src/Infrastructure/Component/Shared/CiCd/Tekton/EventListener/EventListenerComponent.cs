using System.Collections.Generic;
using System.Collections.Immutable;
using Pulumi;
using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Rbac.V1;
using Pulumi.Kubernetes.Types.Inputs.Core.V1;
using Pulumi.Kubernetes.Types.Inputs.Meta.V1;
using Pulumi.Kubernetes.Types.Inputs.Rbac.V1;

namespace Infrastructure.Component.Shared.CiCd.Tekton.EventListener
{
    public class EventListenerComponent : IComponent<EventListenerComponentInput, EventListenerComponentOutput>
    {
        public EventListenerComponentOutput Apply(EventListenerComponentInput input)
        {
            var serviceAccount = new ServiceAccount("trigger-service-account", new ServiceAccountArgs
            {
                Metadata = new ObjectMetaArgs
                {
                    Name = "trigger-service-account",
                    Namespace = input.Namespace.Metadata.Apply(_ => _.Name)
                }
            });
            var role = new ClusterRole("trigger-cluster-role", new ClusterRoleArgs
            {
                Metadata = new ObjectMetaArgs
                {
                    Name = "trigger-role",
                    Namespace = input.Namespace.Metadata.Apply(_ => _.Name)
                },
                Rules = new InputList<PolicyRuleArgs>
                {
                    new PolicyRuleArgs
                    {
                        ApiGroups = { "triggers.tekton.dev" },
                        Resources =
                        {
                            "eventlisteners",
                            "triggers",
                            "triggerbindings",
                            "triggertemplates",
                            "interceptors",
                            "clusterinterceptors",
                            "clustertriggerbindings"
                        },
                        Verbs =
                        {
                            "get",
                            "list",
                            "watch"
                        }
                    },
                    new PolicyRuleArgs
                    {
                        ApiGroups = { "tekton.dev" },
                        Resources = { "pipelineruns", "pipelineresources" },
                        Verbs = { "create" }
                    },
                    new PolicyRuleArgs
                    {
                        ApiGroups = { "" },
                        Resources = { "comfigmaps" },
                        Verbs = { "get", "list", "watch" }
                    }
                }
            });
            var roleBinding = new ClusterRoleBinding("trigger-cluster-role-binding", new ClusterRoleBindingArgs
            {
                Metadata = new ObjectMetaArgs
                {
                    Name = "trigger-role-binding",
                    Namespace = "tekton-pipelines"
                },
                Subjects = new InputList<SubjectArgs>
                {
                    new SubjectArgs
                    {
                        Kind = nameof(ServiceAccount),
                        Name = serviceAccount.Metadata.Apply(_ => _.Name),
                        Namespace = input.Namespace.Metadata.Apply(_ => _.Name)
                    }
                },
                RoleRef = new RoleRefArgs
                {
                    ApiGroup = "rbac.authorization.k8s.io",
                    Kind = nameof(ClusterRole),
                    Name = role.Metadata.Apply(_ => _.Name)
                }
            });

            // NOTE: Does not works.
            // see https://github.com/tektoncd/triggers/issues/1490
            _ = new Pulumi.Crds.Triggers.V1Alpha1.EventListener("build-image-event-listener",
                new Dictionary<string, object>
                {
                    ["apiVersion"] = "triggers.tekton.dev/v1alpha1",
                    ["kind"] = "EventListener",
                    ["metadata"] = new Dictionary<string, object>
                    {
                        ["name"] = "build-image-listener",
                        ["namespace"] = input.Namespace.Metadata.Apply(x => x.Name)
                    }.ToImmutableDictionary(),
                    ["spec"] = new Dictionary<string, object>
                    {
                        ["serviceAccountName"] = serviceAccount.Metadata.Apply(x => x.Name),
                        ["triggers"] = new List<ImmutableDictionary<string, object>>
                        {
                            new Dictionary<string, object>
                            {
                                ["name"] = "build-image-trigger",
                                ["bindings"] = new List<ImmutableDictionary<string, object>>
                                {
                                    new Dictionary<string, object>
                                    {
                                        ["ref"] = "build-image-pipeline-binding"
                                    }.ToImmutableDictionary()
                                }.ToImmutableArray(),
                                ["template"] = new Dictionary<string, object>
                                {
                                    ["ref"] = "build-image-pipeline-template"
                                }.ToImmutableDictionary()
                            }.ToImmutableDictionary()
                        }.ToImmutableArray(),
                        ["resources"] = new InputMap<object>
                        {
                            ["kubernetesResource"] = new InputMap<string>
                            {
                                ["serviceType"] = "NodePort"
                            }
                        }
                    }.ToImmutableDictionary()
                }.ToImmutableDictionary()!,
                new CustomResourceOptions { DependsOn = { input.TektonRelease, input.TektonTrigger, roleBinding } });

            return new EventListenerComponentOutput();
        }
    }
}