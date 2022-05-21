using System.Collections.Immutable;
using Microsoft.Extensions.Logging;
using Pulumi;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.CI_CD.Component
{
    public class Tekton
    {
        private readonly ILogger<Tekton> _logger;
        private Config _config;

        public Tekton(ILogger<Tekton> logger, Config config)
        {
            _logger = logger;
            _config = config;
        }

        public void Apply()
        {
            var configFile = new ConfigFile("tekton-controller-release", new ConfigFileArgs
            {
                File = "https://storage.googleapis.com/tekton-releases/pipeline/previous/v0.35.0/release.yaml",
                // Transformations =
                // {
                //     TransformNamespace
                // }
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

        }

        private ImmutableDictionary<string, object> TransformNamespace(ImmutableDictionary<string, object> obj, CustomResourceOptions opts)
        {
            var metadata = (ImmutableDictionary<string, object>)obj["metadata"];
            if (!metadata.ContainsKey("namespace")) return obj;
            return obj.SetItem("metadata", metadata.SetItem("namespace", Define.Namespace));
        }
    }
}