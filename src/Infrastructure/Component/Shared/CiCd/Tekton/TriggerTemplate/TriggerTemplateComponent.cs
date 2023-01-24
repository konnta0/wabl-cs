using Pulumi;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.Component.Shared.CiCd.Tekton.TriggerTemplate
{
    public class TriggerTemplateComponent : IComponent<TriggerTemplateComponentInput, TriggerTemplateComponentOutput>
    {
        public TriggerTemplateComponentOutput Apply(TriggerTemplateComponentInput input)
        {
            _ = new ConfigFile("build-image-trigger-template", new ConfigFileArgs
                {
                    File = "./Component/Shared/CiCd/Tekton/TriggerTemplate/Yaml/build-image.yaml"
                },
                new ComponentResourceOptions
                    { DependsOn = { input.TektonRelease, input.TektonTrigger, input.Namespace } });

            return new TriggerTemplateComponentOutput();
        }
    }
}