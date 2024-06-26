using Infrastructure.Pulumi.Extension;
using Infrastructure.Pulumi.Component.Tool.ManagementConsole;
using Microsoft.Extensions.Logging;
using Pulumi;
using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Types.Inputs.Core.V1;
using Pulumi.Kubernetes.Types.Inputs.Meta.V1;

namespace Infrastructure.Pulumi.Component.Tool;

public sealed class ToolComponent : IComponent<ToolComponentInput, ToolComponentOutput>
{
    private readonly ILogger<ToolComponent> _logger;
    private readonly ManagementConsoleComponent _managementConsoleComponent;
    private readonly Config _config;

    public ToolComponent(
        ILogger<ToolComponent> logger,
        ManagementConsoleComponent managementConsoleComponent,
        Config config
    )
    {
        _logger = logger;
        _managementConsoleComponent = managementConsoleComponent;
        _config = config;
    }
    
    
    public ToolComponentOutput Apply(ToolComponentInput input)
    {
        var @namespace = new Namespace("namespace-tool", new NamespaceArgs
        {
            Metadata = new ObjectMetaArgs
            {
                Name = _config.GetToolConfig().Namespace
            }
        });

        if (_config.GetManagementConsoleConfig().Deploy)
        {
            _managementConsoleComponent.Apply(new ManagementConsoleComponentInput
            {
                Namespace = @namespace
            });
        }
        
        return new ToolComponentOutput();
    }
}