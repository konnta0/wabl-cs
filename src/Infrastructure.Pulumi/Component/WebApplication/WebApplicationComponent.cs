using Infrastructure.Pulumi.Extension;
using Infrastructure.Pulumi.Component.WebApplication.OpenTelemetryOperator;
using Infrastructure.Pulumi.Component.WebApplication.WebApi;
using Microsoft.Extensions.Logging;
using Pulumi;
using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Types.Inputs.Core.V1;
using Pulumi.Kubernetes.Types.Inputs.Meta.V1;

namespace Infrastructure.Pulumi.Component.WebApplication
{
    public class WebApplicationComponent : IComponent<WebApplicationComponentInput, WebApplicationComponentOutput>
    {
        private readonly ILogger<WebApplicationComponent> _logger;
        private Config _config;
        private readonly WebApiComponent _webApiComponent;
        private readonly OpenTelemetryOperatorComponent _openTelemetryOperatorComponent;

        public WebApplicationComponent(
            ILogger<WebApplicationComponent> logger,
            Config config, 
            WebApiComponent webApiComponent,
            OpenTelemetryOperatorComponent openTelemetryOperatorComponent)
        {
            _logger = logger;
            _config = config;
            _webApiComponent = webApiComponent;
            _openTelemetryOperatorComponent = openTelemetryOperatorComponent;
        }

        public WebApplicationComponentOutput Apply(WebApplicationComponentInput input)
        {
            if (!_config.GetWebApplicationConfig().Deploy)
            {
                return new WebApplicationComponentOutput();
            }
            
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
            
            _webApiComponent.Apply(new WebApiComponentInput
            {
                Namespace = @namespace,
                Tag = _config.GetWebApplicationConfig().Tag,
                OpenTelemetryCrd = openTelemetryOperatorComponentOutput.OpenTelemetryCrd
            });
            return new WebApplicationComponentOutput();
        }
    }
}