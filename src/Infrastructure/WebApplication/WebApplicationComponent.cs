using System.Collections.Immutable;
using Infrastructure.WebApplication.Resource;
using Infrastructure.Extension;
using Infrastructure.WebApplication.Resource.Dotnet;
using Infrastructure.WebApplication.Resource.Dragonfly;
using Infrastructure.WebApplication.Resource.TiDB;
using Microsoft.Extensions.Logging;
using Pulumi;
using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Types.Inputs.Core.V1;
using Pulumi.Kubernetes.Types.Inputs.Meta.V1;

namespace Infrastructure.WebApplication
{
    public class WebApplicationComponent
    {
        private readonly ILogger<WebApplicationComponent> _logger;
        private Config _config;
        private readonly TiDBResource _tiDbResource;
        private readonly DragonflyResource _dragonflyResource;
        private readonly DotnetApplicationResource _dotnetApplicationResource;

        public WebApplicationComponent(ILogger<WebApplicationComponent> logger, Config config, 
            TiDBResource tiDbResource, 
            DragonflyResource dragonflyResource, 
            DotnetApplicationResource dotnetApplicationResource)
        {
            _logger = logger;
            _config = config;
            _tiDbResource = tiDbResource;
            _dragonflyResource = dragonflyResource;
            _dotnetApplicationResource = dotnetApplicationResource;
        }

        public string Apply()
        {
            var @namespace = new Namespace("namespace-web-application", new NamespaceArgs
            {
                Metadata = new ObjectMetaArgs
                {
                    Name = _config.GetWebApplicationConfig().Namespace
                }
            });
            _ = @namespace.Metadata.Apply(x => x.Name);

            _tiDbResource.Apply();
            _dragonflyResource.Apply();
            _dotnetApplicationResource.Apply();

            return string.Empty;
        }
    }
}