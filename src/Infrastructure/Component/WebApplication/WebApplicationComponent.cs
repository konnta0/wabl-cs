using System.Text.Json;
using Infrastructure.Component.WebApplication.OpenTelemetryOperator;
using Infrastructure.Component.WebApplication.Promtail;
using Infrastructure.Component.WebApplication.WebApi;
using Infrastructure.Extension;
using Microsoft.Extensions.Logging;
using Pulumi;
using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Types.Inputs.Core.V1;
using Pulumi.Kubernetes.Types.Inputs.Meta.V1;

namespace Infrastructure.Component.WebApplication
{
    public class WebApplicationComponent : IComponent<WebApplicationComponentInput, WebApplicationComponentOutput>
    {
        private readonly ILogger<WebApplicationComponent> _logger;
        private Config _config;
        private readonly WebApiComponent _webApiComponent;
        private readonly OpenTelemetryOperatorComponent _openTelemetryOperatorComponent;
        private readonly PromtailComponent _promtailComponent;

        public WebApplicationComponent(
            ILogger<WebApplicationComponent> logger,
            Config config, 
            WebApiComponent webApiComponent,
            OpenTelemetryOperatorComponent openTelemetryOperatorComponent,
            PromtailComponent promtailComponent)
        {
            _logger = logger;
            _config = config;
            _webApiComponent = webApiComponent;
            _openTelemetryOperatorComponent = openTelemetryOperatorComponent;
            _promtailComponent = promtailComponent;
        }

        public WebApplicationComponentOutput Apply(WebApplicationComponentInput input)
        {
            var @namespace = new Namespace("namespace-web-application", new NamespaceArgs
            {
                Metadata = new ObjectMetaArgs
                {
                    Name = _config.GetWebApplicationConfig().Namespace
                }
            });

            var openTelemetryOperatorComponentOutput = _openTelemetryOperatorComponent.Apply(new OpenTelemetryOperatorComponentInput
            {
                Namespace = @namespace
            });

            if (_config.RequireObject<JsonElement>("Observability").GetProperty("Enable").GetBoolean())
            {
                _promtailComponent.Apply(new PromtailComponentInput
                {
                    Namespace = @namespace
                });
            }
            
            _webApiComponent.Apply(new WebApiComponentInput
            {
                Namespace = @namespace,
                OpenTelemetryCrd = openTelemetryOperatorComponentOutput.OpenTelemetryCrd
            });
            return new WebApplicationComponentOutput();
        }
    }
}