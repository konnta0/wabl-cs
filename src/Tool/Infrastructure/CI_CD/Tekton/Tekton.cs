using Microsoft.Extensions.Logging;
using Pulumi;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.CI_CD.Tekton
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
                File = "https://storage.googleapis.com/tekton-releases/pipeline/latest/release.yaml"
            });
            configFile.Ready();

            var dashboardConfigFile = new ConfigFile("tekton-dashboard-release", new ConfigFileArgs
            {
                File = "https://github.com/tektoncd/dashboard/releases/latest/download/tekton-dashboard-release.yaml"
            });
            dashboardConfigFile.Ready();
            
            var triggersConfigFile = new ConfigFile("tekton-triggers-release", new ConfigFileArgs
            {
                File = "https://storage.googleapis.com/tekton-releases/triggers/latest/release.yaml"
            });
            triggersConfigFile.Ready();
        }
    }
}