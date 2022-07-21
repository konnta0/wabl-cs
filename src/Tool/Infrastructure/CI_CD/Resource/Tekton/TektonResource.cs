using System.Collections.Generic;
using System.Collections.Immutable;
using Infrastructure.Extension;
using Microsoft.Extensions.Logging;
using Pulumi;
using Pulumi.Kubernetes.Types.Inputs.Meta.V1;
using Pulumi.Kubernetes.Types.Inputs.Networking.V1;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.CI_CD.Resource.Tekton
{
    public class TektonResource
    {
        
        private readonly ILogger<TektonResource> _logger;
        private readonly Config _config;
        private readonly PipelineResource _pipelineResource;
        private readonly ServiceAccount _serviceAccount;
        private readonly ClusterRoleBinding _clusterRoleBinding;
        private readonly TektonTask _tektonTask;
        private readonly Pipeline _pipeline;
        private readonly TektonTaskRun _tektonTaskRun;
        private readonly Secret _secret;
        private readonly PipelineRun _pipelineRun;

        public TektonResource(ILogger<TektonResource> logger, 
            Config config, 
            PipelineResource pipelineResource, 
            ServiceAccount serviceAccount, 
            ClusterRoleBinding clusterRoleBinding,
            TektonTask tektonTask,
            Pipeline pipeline,
            TektonTaskRun tektonTaskRun,
            Secret secret,
            PipelineRun pipelineRun)
        {
            _logger = logger;
            _config = config;
            _pipelineResource = pipelineResource;
            _serviceAccount = serviceAccount;
            _clusterRoleBinding = clusterRoleBinding;
            _tektonTask = tektonTask;
            _pipeline = pipeline;
            _tektonTaskRun = tektonTaskRun;
            _secret = secret;
            _pipelineRun = pipelineRun;
        }

        public void Apply()
        {
            _ = new ConfigFile("tekton-controller-release", new ConfigFileArgs
            {
                File = "https://storage.googleapis.com/tekton-releases/pipeline/previous/v0.35.0/release.yaml",
                Transformations =
                {
                    //TransformTektonNamespace,
                    HpaV2beta1ToV1,
                    //TransformNamespace
                }
            });

            _ = new ConfigFile("tekton-dashboard-release", new ConfigFileArgs
            {
                File = "https://github.com/tektoncd/dashboard/releases/download/v0.25.0/tekton-dashboard-release.yaml",
                // Transformations =
                // {
                //     TransformNamespace
                // }                
            });

            _ = new ConfigFile("tekton-triggers-release", new ConfigFileArgs
            {
                File = "https://storage.googleapis.com/tekton-releases/triggers/previous/v0.19.1/release.yaml",
                // Transformations =
                // {
                //     TransformNamespace
                // }                
            });

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
            
            _pipelineResource.Apply();
            _secret.Apply();
            _serviceAccount.Apply();
            _clusterRoleBinding.Apply();
            _tektonTask.Apply();
            _pipeline.Apply();
            _tektonTaskRun.Apply();
            _pipelineRun.Apply();
        }

        private ImmutableDictionary<string, object> TransformTektonNamespace(ImmutableDictionary<string, object> obj, CustomResourceOptions opts)
        {
            if (!obj.ContainsKey("kind")) return obj;
            
            if ((string)obj["kind"] != "Namespace") return obj;
            
            var metadata = (ImmutableDictionary<string, object>)obj["metadata"];
            if (!metadata.ContainsKey("name")) return obj;

            return obj.SetItem("metadata", metadata.SetItem("name", _config.GetCICDConfig().Namespace));
        }

        private ImmutableDictionary<string, object> TransformNamespace(ImmutableDictionary<string, object> obj, CustomResourceOptions opts)
        {
            var metadata = (ImmutableDictionary<string, object>)obj["metadata"];
            if (!metadata.ContainsKey("namespace")) return obj;
            return obj.SetItem("metadata", metadata.SetItem("namespace", _config.GetCICDConfig().Namespace));
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
    }
}