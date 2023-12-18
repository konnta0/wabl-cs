using System.Diagnostics.Contracts;
using Pulumi;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.Pulumi.Component.WebApplication.OpenTelemetryOperator
{
    public class OpenTelemetryOperatorComponent : IComponent<OpenTelemetryOperatorComponentInput, OpenTelemetryOperatorComponentOutput>
    {
        private readonly Config _config;

        public OpenTelemetryOperatorComponent(Config config)
        {
            _config = config;
        }

        [Pure]
        public OpenTelemetryOperatorComponentOutput Apply(OpenTelemetryOperatorComponentInput input)
        {
            var configFile = new ConfigFile("opentelemetry-operator", new ConfigFileArgs
            {
                File = "https://github.com/open-telemetry/opentelemetry-operator/releases/download/v0.60.0/opentelemetry-operator.yaml"
            }, new ComponentResourceOptions { DependsOn = input.Namespace });
            return new OpenTelemetryOperatorComponentOutput
            {
                OpenTelemetryCrd = configFile
            };
        }
    }
}