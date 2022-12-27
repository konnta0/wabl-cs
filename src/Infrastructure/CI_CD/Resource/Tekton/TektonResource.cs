using System.Collections.Generic;
using System.Collections.Immutable;
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
        private readonly ServiceAccount _serviceAccount;
        private readonly ClusterRole _clusterRole;
        private readonly ClusterRoleBinding _clusterRoleBinding;
        private readonly TektonTask _tektonTask;
        private readonly Pipeline _pipeline;
        private readonly TektonTaskRun _tektonTaskRun;
        private readonly Secret _secret;
        private readonly PipelineRun _pipelineRun;

        public TektonResource(ILogger<TektonResource> logger, 
            Config config, 
            ServiceAccount serviceAccount, 
            ClusterRole clusterRole,
            ClusterRoleBinding clusterRoleBinding,
            TektonTask tektonTask,
            Pipeline pipeline,
            TektonTaskRun tektonTaskRun,
            Secret secret,
            PipelineRun pipelineRun)
        {
            _logger = logger;
            _config = config;
            _serviceAccount = serviceAccount;
            _clusterRole = clusterRole;
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
            
            _secret.Apply();
            _serviceAccount.Apply();
            _clusterRole.Apply();
            _clusterRoleBinding.Apply();
            _tektonTask.Apply();
            _pipeline.Apply();
            _tektonTaskRun.Apply();
            _pipelineRun.Apply();
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