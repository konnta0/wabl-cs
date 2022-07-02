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

        public TektonResource(ILogger<TektonResource> logger, Config config, PipelineResource pipelineResource)
        {
            _logger = logger;
            _config = config;
            _pipelineResource = pipelineResource;
        }

        public void Apply()
        {
            var configFile = new ConfigFile("tekton-controller-release", new ConfigFileArgs
            {
                File = "https://storage.googleapis.com/tekton-releases/pipeline/previous/v0.35.0/release.yaml",
                Transformations =
                {
                    HpaV2beta1ToV1,
                    //TransformNamespace
                }
            });

            var dashboardConfigFile = new ConfigFile("tekton-dashboard-release", new ConfigFileArgs
            {
                File = "https://github.com/tektoncd/dashboard/releases/download/v0.25.0/tekton-dashboard-release.yaml",
                // Transformations =
                // {
                //     TransformNamespace
                // }                
            });

            var triggersConfigFile = new ConfigFile("tekton-triggers-release", new ConfigFileArgs
            {
                File = "https://storage.googleapis.com/tekton-releases/triggers/previous/v0.19.1/release.yaml",
                // Transformations =
                // {
                //     TransformNamespace
                // }                
            });
            var ingress = new Pulumi.Kubernetes.Networking.V1.Ingress("tekton-pipeline-ingress", new IngressArgs
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