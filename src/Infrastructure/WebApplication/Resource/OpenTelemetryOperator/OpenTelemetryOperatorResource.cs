using Pulumi;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.WebApplication.Resource.OpenTelemetryOperator
{
    public class OpenTelemetryOperatorResource
    {
        private readonly Config _config;

        public OpenTelemetryOperatorResource(Config config)
        {
            _config = config;
        }

        public void Apply()
        {
            var configFile = new ConfigFile("open-telemetry-operator", new ConfigFileArgs
            {
                File = "https://github.com/open-telemetry/opentelemetry-operator/releases/download/v0.60.0/opentelemetry-operator.yaml",
                Transformations =
                {
                }
            });
            configFile.Ready();
        }
    }
}