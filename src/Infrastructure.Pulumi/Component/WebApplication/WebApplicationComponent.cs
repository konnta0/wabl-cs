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
    public class WebApplicationComponent(
        ILogger<WebApplicationComponent> logger,
        Config config,
        WebApiComponent webApiComponent,
        OpenTelemetryOperatorComponent openTelemetryOperatorComponent)
        : IComponent<WebApplicationComponentInput, WebApplicationComponentOutput>
    {
        private readonly ILogger<WebApplicationComponent> _logger = logger;

        public WebApplicationComponentOutput Apply(WebApplicationComponentInput input)
        {
            if (!config.GetWebApplicationConfig().Deploy)
            {
                return new WebApplicationComponentOutput();
            }
            
            var @namespace = new Namespace("namespace-web-application", new NamespaceArgs
            {
                Metadata = new ObjectMetaArgs
                {
                    Name = config.GetWebApplicationConfig().Namespace
                }
            });

            var openTelemetryOperatorComponentOutput = openTelemetryOperatorComponent.Apply(new OpenTelemetryOperatorComponentInput
            {
                Namespace = @namespace
            });
            
            webApiComponent.Apply(new WebApiComponentInput
            {
                Namespace = @namespace,
                CanaryTag = config.GetWebApplicationConfig().CanaryTag,
                Tag = config.GetWebApplicationConfig().Tag,
                OpenTelemetryCrd = openTelemetryOperatorComponentOutput.OpenTelemetryCrd
            });
            return new WebApplicationComponentOutput();
        }
    }
}