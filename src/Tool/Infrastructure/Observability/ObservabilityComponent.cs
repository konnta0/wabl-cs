using Infrastructure.Observability.Component;
using Microsoft.Extensions.Logging;
using Pulumi;

namespace Infrastructure.Observability
{
    public class ObservabilityComponent
    {
        private readonly ILogger<ObservabilityComponent> _logger;
        private readonly Grafana _grafana;

        public ObservabilityComponent(ILogger<ObservabilityComponent> logger, Grafana grafana)
        {
            _logger = logger;
            _grafana = grafana;
        }

        public void Apply()
        {
            _grafana.Apply();
            GrafanaNamespace = _grafana.Namespace;
        }

        [Output] public Output<string> GrafanaNamespace { get; set; }
    }
}