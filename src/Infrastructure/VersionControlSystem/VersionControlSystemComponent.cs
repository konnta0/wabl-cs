using Infrastructure.Extension;
using Infrastructure.VersionControlSystem.Resource.GiLab;
using Microsoft.Extensions.Logging;
using Pulumi;
using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Types.Inputs.Core.V1;
using Pulumi.Kubernetes.Types.Inputs.Meta.V1;

namespace Infrastructure.VersionControlSystem
{
    public class VersionControlSystemComponent
    {
        private Config _config;
        private readonly GitLabResource _gitLabResource;
        private readonly ILogger<VersionControlSystemComponent> _logger;
        private Input<string> _namespaceName;

        public VersionControlSystemComponent(ILogger<VersionControlSystemComponent> logger, Config config, GitLabResource gitLabResource)
        {
            _logger = logger;
            _config = config;
            _gitLabResource = gitLabResource;
        }

        public Output<string> Apply()
        {
            var @namespace = new Namespace("namespace-version-control-system", new NamespaceArgs
            {
                Metadata = new ObjectMetaArgs
                {
                    Name = _config.GetVersionControlSystemConfig().Namespace
                }
            });
            _namespaceName = @namespace.Metadata.Apply(x => x.Name);
            return _gitLabResource.Apply(_namespaceName);
        }
    }
}