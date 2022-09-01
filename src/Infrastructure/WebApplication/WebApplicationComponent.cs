using System.Collections.Immutable;
using Infrastructure.WebApplication.Resource;
using Infrastructure.Extension;
using Infrastructure.WebApplication.Resource.Dragonfly;
using Infrastructure.WebApplication.Resource.TiDB;
using Microsoft.Extensions.Logging;
using Pulumi;
using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Types.Inputs.Core.V1;
using Pulumi.Kubernetes.Types.Inputs.Meta.V1;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.WebApplication
{
    public class WebApplicationComponent
    {
        private readonly ILogger<WebApplicationComponent> _logger;
        private Config _config;
        private readonly TiDBResource _tiDbResource;
        private readonly DragonflyResource _dragonflyResource;
        private Input<string> _namespaceName;
        
        public WebApplicationComponent(ILogger<WebApplicationComponent> logger, Config config, TiDBResource tiDbResource, DragonflyResource dragonflyResource)
        {
            _logger = logger;
            _config = config;
            _tiDbResource = tiDbResource;
            _dragonflyResource = dragonflyResource;
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
            _namespaceName = @namespace.Metadata.Apply(x => x.Name);

            _tiDbResource.Apply();
            _dragonflyResource.Apply();
            

            return string.Empty;
        }
    }
}