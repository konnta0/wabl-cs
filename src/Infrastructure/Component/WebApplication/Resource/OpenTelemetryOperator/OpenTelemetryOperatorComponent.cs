using Pulumi;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.Component.WebApplication.Resource.OpenTelemetryOperator
{
    public class OpenTelemetryOperatorComponent : IComponent<OpenTelemetryOperatorComponentInput, OpenTelemetryOperatorComponentOutput>
    {
        private readonly Config _config;

        public OpenTelemetryOperatorComponent(Config config)
        {
            _config = config;
        }

        public OpenTelemetryOperatorComponentOutput Apply(OpenTelemetryOperatorComponentInput input)
        {
            _ = new ConfigFile("open-telemetry-operator", new ConfigFileArgs
            {
                File = "https://github.com/open-telemetry/opentelemetry-operator/releases/download/v0.60.0/opentelemetry-operator.yaml",
            }, new ComponentResourceOptions { DependsOn = input.Namespace });
            return new OpenTelemetryOperatorComponentOutput();
        }
    }
}