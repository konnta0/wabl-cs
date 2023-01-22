using Pulumi;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.Component.Shared.CiCd.Tekton.TriggerBinding
{
    public class TriggerBindingComponent : IComponent<TriggerBindingComponentInput, TriggerBindingComponentOutput>
    {
        public TriggerBindingComponentOutput Apply(TriggerBindingComponentInput input)
        {
            _ = new ConfigFile("build-image-trigger-binding", new ConfigFileArgs
            {
                File = "./Component/Shared/CiCd/Tekton/TriggerBinding/Yaml/build-image.yaml"
            }, new ComponentResourceOptions {DependsOn = {input.TektonRelease, input.TektonTrigger}});

            return new TriggerBindingComponentOutput();
        }
    }
}