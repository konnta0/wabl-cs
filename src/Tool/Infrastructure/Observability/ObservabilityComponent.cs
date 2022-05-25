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
            GrafanaHost = _grafana.IngressHost;
        }

        [Output] public Output<string> GrafanaHost { get; set; }
    }
}