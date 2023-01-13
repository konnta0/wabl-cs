using System.Collections.Generic;
using System.Collections.Immutable;
using Infrastructure.Extension;
using Microsoft.Extensions.Logging;
using Pulumi;
using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Types.Inputs.Core.V1;
using Pulumi.Kubernetes.Types.Inputs.Meta.V1;
using Pulumi.Kubernetes.Types.Inputs.Networking.V1;
using Pulumi.Kubernetes.Types.Inputs.Rbac.V1;
using Pulumi.Kubernetes.Yaml;
using Config = Pulumi.Config;
using SecretArgs = Pulumi.Kubernetes.Types.Inputs.Core.V1.SecretArgs;

namespace Infrastructure.Component.Shared.CiCd.Tekton
{
    public class TektonComponent : IComponent<TektonComponentInput, TektonComponentOutput>
    {
        
        private readonly ILogger<TektonComponent> _logger;
        private readonly Config _config;
        private readonly TektonTask _tektonTask;
        private readonly Pipeline _pipeline;
        private readonly TektonTaskRun _tektonTaskRun;
        private readonly PipelineRun _pipelineRun;

        public TektonComponent(ILogger<TektonComponent> logger, 
            Config config, 
            TektonTask tektonTask,
            Pipeline pipeline,
            TektonTaskRun tektonTaskRun,
            PipelineRun pipelineRun)
        {
            _logger = logger;
            _config = config;
            _tektonTask = tektonTask;
            _pipeline = pipeline;
            _tektonTaskRun = tektonTaskRun;
            _pipelineRun = pipelineRun;
        }

        public void Apply()
        {
            _ = new ConfigFile("tekton-controller-release", new ConfigFileArgs
            {
                File = "https://storage.googleapis.com/tekton-releases/pipeline/previous/v0.39.0/release.yaml",
                Transformations =
                {
                    //TransformTektonNamespace,
                    HpaV2beta1ToV1,
                    //TransformNamespace
                }
            }).Ready();

            _ = new ConfigFile("tekton-dashboard-release", new ConfigFileArgs
            {
                File = "https://github.com/tektoncd/dashboard/releases/download/v0.29.2/tekton-dashboard-release.yaml"
            }).Ready();

            _ = new ConfigFile("tekton-dashboard-extension-cronjob", new ConfigFileArgs
            {
                File = "./CI_CD/Resource/Tekton/Yaml/dashboard-extension-cronjob.yaml"
            }).Ready();
            
            _ = new ConfigFile("tekton-triggers-release", new ConfigFileArgs
            {
                File = "https://storage.googleapis.com/tekton-releases/triggers/previous/v0.21.0/release.yaml"
            }).Ready();

            _ = new Pulumi.Kubernetes.Networking.V1.Ingress("tekton-pipeline-ingress", new IngressArgs
            {
                ApiVersion = "networking.k8s.io/v1",
                Metadata = new ObjectMetaArgs
                {
                    Name = "tekton-dashboard-ingress",
                    Namespace = "tekton-pipelines"
                },
                Spec = new IngressSpecArgs
                {
                    IngressClassName = "nginx",
                    Rules = new List<IngressRuleArgs>
                    {
                        new IngressRuleArgs
                        {
                            Host = "tekton.dashboard.cicd.test",
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
                                            Name = "tekton-dashboard",
                                            Port = new ServiceBackendPortArgs { Number = 9097 }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            });
            
            _tektonTask.Apply();
            _pipeline.Apply();
            _tektonTaskRun.Apply();
            _pipelineRun.Apply();
        }

        public TektonComponentOutput Apply(TektonComponentInput input)
        {
            var tektonRelease = new ConfigFile("tekton-controller-release", new ConfigFileArgs
            {
                File = "https://storage.googleapis.com/tekton-releases/pipeline/previous/v0.43.1/release.yaml",
                Transformations =
                {
                    HpaV2beta1ToV1,
                    TransformNamespace
                }
            }, new ComponentResourceOptions {DependsOn = input.Namespace});

            var dashboard = new ConfigFile("tekton-dashboard-release", new ConfigFileArgs
            {
                File = "https://github.com/tektoncd/dashboard/releases/download/v0.31.0/tekton-dashboard-release.yaml"
            }, new ComponentResourceOptions {DependsOn = {tektonRelease}});

            var cronjob = new ConfigFile("tekton-dashboard-extension-cronjob", new ConfigFileArgs
            {
                File = "./Component/CiCd/Tekton/Yaml/dashboard-extension-cronjob.yaml"
            }, new ComponentResourceOptions {DependsOn = {tektonRelease, dashboard}});

            var triggers = new ConfigFile("tekton-triggers-release", new ConfigFileArgs
            {
                File = "https://storage.googleapis.com/tekton-releases/triggers/previous/v0.22.0/release.yaml"
            }, new ComponentResourceOptions {DependsOn = {tektonRelease}});

            var interceptor = new ConfigFile("tekton-triggers-interceptor-release", new ConfigFileArgs
            {
                File = "https://storage.googleapis.com/tekton-releases/triggers/previous/v0.22.0/interceptors.yaml"
            }, new ComponentResourceOptions {DependsOn = {tektonRelease, triggers}});
            
            var secret = new Secret("tekton-pipeline-secret-container-registry", new SecretArgs
            {
                Type = "kubernetes.io/basic-auth",
                Immutable = true,
                StringData = new Dictionary<string, string>
                {
                    ["username"] = _config.GetCICDConfig().RegistryAccess.UserName,
                    ["password"] = _config.GetCICDConfig().RegistryAccess.PassWord
                },
                Metadata = new ObjectMetaArgs
                {
                    Name = "tekton-pipeline-secret-for-container-registry",
                    Namespace = input.Namespace.Metadata.Apply(x => x.Name),
                    Annotations = new Dictionary<string, string>
                    {
                        // https://tekton.dev/vault/pipelines-v0.16.3/auth/#configuring-basic-auth-authentication-for-docker
                        ["tekton.dev/docker-0"] = "core.harbor.cr.test"
                    }
                }
            });

            var serviceAccount = new ServiceAccount("tekton-pipeline-service-account", new ServiceAccountArgs
            {
                Metadata = new ObjectMetaArgs
                {
                    Labels = {{"app", "tekton-dashboard"}},
                    Name = "tekton-dashboard-service-account",
                    Namespace = input.Namespace.Metadata.Apply(x => x.Name)
                },
                Secrets =
                {
                    new ObjectReferenceArgs
                    {
                        Name = secret.Metadata.Apply(x => x.Name)
                    }
                }
            });

            var clusterRole = new Pulumi.Kubernetes.Rbac.V1.ClusterRole("tekton-pipeline-cluster-role", new ClusterRoleArgs
            {
                Metadata = new ObjectMetaArgs
                {
                    Name = "tekton-dashboard-cluster-admin",
                    Labels = {{"rbac.dashboard.tekton.dev/aggregate-to-dashboard", bool.TrueString.ToLower()}},
                    Namespace = input.Namespace.Metadata.Apply(x => x.Name)
                },
                Rules =
                {
                    new PolicyRuleArgs
                    {
                        ApiGroups = {"batch"},
                        Resources = {"cronjobs"},
                        Verbs = {"get", "list"}
                    }
                }
            });

            var clusterRoleBinding = new Pulumi.Kubernetes.Rbac.V1.ClusterRoleBinding("tekton-pipeline-cluster-role-binding", new ClusterRoleBindingArgs
            {
                Metadata = new ObjectMetaArgs
                {
                    Name = "dashboard-cluster-admin"
                },
                RoleRef = new RoleRefArgs
                {
                    ApiGroup = "rbac.authorization.k8s.io",
                    Kind = nameof(Pulumi.Kubernetes.Rbac.V1.ClusterRole),
                    Name = clusterRole.Metadata.Apply(x => x.Name)
                },
                Subjects =
                {
                    new SubjectArgs
                    {
                        Kind = nameof(ServiceAccount),
                        Name = serviceAccount.Metadata.Apply(x => x.Name),
                        Namespace = serviceAccount.Metadata.Apply(x => x.Namespace)
                    }
                }
            });

            return new TektonComponentOutput();
        }

        private ImmutableDictionary<string, object> HpaV2beta1ToV1(ImmutableDictionary<string, object> obj,
            CustomResourceOptions options)
        {
            // measures for below warning
            // Diagnostics:
            // kubernetes:autoscaling/v2beta1:HorizontalPodAutoscaler (tekton-pipelines/tekton-pipelines-webhook):
            // warning: autoscaling/v2beta1/HorizontalPodAutoscaler is deprecated by autoscaling/v1/HorizontalPodAutoscaler.

            if (!obj.TryGetValue("apiVersion", out var apiVersion)) return obj;
            if ((string)apiVersion != "autoscaling/v2beta1") return obj;
            return obj.SetItem("apiVersion", "autoscaling/v1");
        }
        
        private ImmutableDictionary<string, object> TransformNamespace(ImmutableDictionary<string, object> obj, CustomResourceOptions opts)
        {
            var kind = (string)obj["kind"];
            var metadata = (ImmutableDictionary<string, object>)obj["metadata"];
            if (kind is "Namespace" && (string)metadata.GetValueOrDefault("name")! is "tekton-pipelines")
            {
                return obj.SetItem("metadata", metadata.SetItem("name", "shared"));
            }

            if (metadata.ContainsKey("namespace") && (string)metadata.GetValueOrDefault("name")! is "tekton-pipelines")
            {
                return obj.SetItem("metadata", metadata.SetItem("namespace", "tekton-pipelines"));
            }

            return obj; // nop
        }
    }
}