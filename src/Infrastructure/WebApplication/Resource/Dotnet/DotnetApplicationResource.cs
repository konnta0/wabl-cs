using Infrastructure.Extension;
using Pulumi;
using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Types.Inputs.Apps.V1;
using Pulumi.Kubernetes.Types.Inputs.Core.V1;
using Pulumi.Kubernetes.Types.Inputs.Meta.V1;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.WebApplication.Resource.Dotnet
{
    public class DotnetApplicationResource
    {
        private readonly Config _config;

        public DotnetApplicationResource(Config config)
        {
            _config = config;
        }

        public void Apply()
        {
            var secret = new ConfigFile("web-application-dotnet-application-secret", new ConfigFileArgs
            {
                File = "./WebApplication/Resource/Dotnet/Yaml/dotnetapp-secret-local.yaml"
            });
            secret.Ready();

            var deployment = new Pulumi.Kubernetes.Apps.V1.Deployment("web-application-dotnet-application",
                new DeploymentArgs
                {
                    Metadata = new ObjectMetaArgs
                    {
                        Labels =
                        {
                            { "app", "web" }
                        },
                        Namespace = _config.GetWebApplicationConfig().Namespace,
                    },
                    Spec = new DeploymentSpecArgs
                    {
                        Replicas = 2,
                        Selector = new LabelSelectorArgs
                        {
                            MatchLabels =
                            {
                                { "app", "web" }
                            }
                        },
                        Template = new PodTemplateSpecArgs
                        {
                            Metadata = new ObjectMetaArgs
                            {
                                Labels =
                                {
                                    { "app", "web" }
                                }
                            },
                            Spec = new PodSpecArgs
                            {
                                Containers =
                                {
                                    new ContainerArgs
                                    {
                                        Image = "core.harbor.cr.test/webapp/dotnetapp:latest",
                                        Name = "dotnetapp",
                                        Ports = 
                                        {
                                            new ContainerPortArgs
                                            {
                                                ContainerPortValue = 80
                                            }
                                        },
                                        EnvFrom = new EnvFromSourceArgs
                                        {
                                            SecretRef = new SecretEnvSourceArgs
                                            {
                                                Name = "dotnetapp-secret"
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                });
            
            // service
            // ingress
        }
    }
}