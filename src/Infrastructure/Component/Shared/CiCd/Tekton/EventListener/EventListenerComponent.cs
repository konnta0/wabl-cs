using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Text.Json;
using Pulumi;
using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Networking.V1;
using Pulumi.Kubernetes.Rbac.V1;
using Pulumi.Kubernetes.Types.Inputs.Core.V1;
using Pulumi.Kubernetes.Types.Inputs.Meta.V1;
using Pulumi.Kubernetes.Types.Inputs.Networking.V1;
using Pulumi.Kubernetes.Types.Inputs.Rbac.V1;

namespace Infrastructure.Component.Shared.CiCd.Tekton.EventListener
{
    public class EventListenerComponent : IComponent<EventListenerComponentInput, EventListenerComponentOutput>
    {
        private readonly Config _config;

        public EventListenerComponent(Config config)
        {
            _config = config;
        }

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

            var containerRegistryConfig = _config.RequireObject<JsonElement>("ContainerRegistry");
            var userName = containerRegistryConfig.GetProperty("Access").GetProperty("CI").GetProperty("User")
                .GetString();
            var password = containerRegistryConfig.GetProperty("Access").GetProperty("CI").GetProperty("Password")
                .GetString();
            var email = containerRegistryConfig.GetProperty("Access").GetProperty("CI").GetProperty("Email")
                .GetString();
            var dockerConfig = new Dictionary<string, object>
            {
                ["auths"] = new Dictionary<string, object>
                {
                    ["https://core.harbor.cr.test/v2/"] = new Dictionary<string, object>
                    {
                        ["auth"] = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{userName}:{password}")),
                        ["username"] = userName,
                        ["password"] = password,
                        ["email"] = email
                    }
                }
            };

            var dockerSecret = new Secret("docker-config", new SecretArgs
            {
                Metadata = new ObjectMetaArgs
                {
                    Name = "docker-config",
                    Namespace = "tekton-worker"
                },
                Immutable = true,
                StringData = new InputMap<string>
                {
                    ["config.json"] = JsonSerializer.Serialize(dockerConfig)
                }
            });
            
            var buildBotServiceAccount = new ServiceAccount("build-bot-service-account", new ServiceAccountArgs
            {
                Metadata = new ObjectMetaArgs
                {
                    Name = "build-bot-service-account",
                    Namespace = input.Namespace.Metadata.Apply(_ => _.Name)
                },
                Secrets = new InputList<ObjectReferenceArgs>
                {
                    new ObjectReferenceArgs
                    {
                        Name = dockerSecret.Metadata.Apply(x => x.Name)
                    }
                }
            });

            var eventListener = new Pulumi.Crds.Triggers.V1Alpha1.EventListener("build-image-event-listener",
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
                        ["triggers"] = new InputList<ImmutableDictionary<string, object>>
                        {
                            new Dictionary<string, object>
                            {
                                ["name"] = "build-image-trigger",
                                ["bindings"] = new InputList<InputMap<object>>
                                {
                                    new InputMap<object>
                                    {
                                        ["ref"] = "build-image-pipeline-binding"
                                    }
                                },
                                ["template"] = new InputMap<object>
                                {
                                    ["ref"] = "build-image-pipeline-template"
                                }
                            }.ToImmutableDictionary()
                        },
                        ["resources"] = new InputMap<object>
                        {
                            ["kubernetesResource"] = new InputMap<object>
                            {
                                ["serviceType"] = "NodePort"
                            }
                        }
                    }.ToImmutableDictionary()
                }.ToImmutableDictionary()!,
                new CustomResourceOptions { DependsOn = { input.TektonRelease, input.TektonTrigger, roleBinding } });

            var ingress = new Ingress("tekton-event-listener-ingress", new IngressArgs
            {
                Metadata = new ObjectMetaArgs
                {
                    Name = "tekton-event-listener-ingress",
                    Namespace = input.Namespace.Metadata.Apply(x => x.Name)
                },
                Spec = new IngressSpecArgs
                {
                    IngressClassName = "nginx",
                    Rules =
                    {
                        new IngressRuleArgs
                        {
                            Host = "image.build.el.cicd.test",
                            Http = new HTTPIngressRuleValueArgs
                            {
                                Paths = new HTTPIngressPathArgs
                                {
                                    Path = "/",
                                    PathType = "Prefix",
                                    Backend = new IngressBackendArgs
                                    {
                                        Service = new IngressServiceBackendArgs
                                        {
                                            Name = eventListener.Metadata.Apply(x => "el-" + x.Name),
                                            Port = new ServiceBackendPortArgs
                                            {
                                                Number = 8080
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            });
            return new EventListenerComponentOutput();
        }
    }
}