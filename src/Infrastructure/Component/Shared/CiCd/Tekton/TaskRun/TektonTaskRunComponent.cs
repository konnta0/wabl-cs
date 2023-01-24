using Pulumi;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.Component.Shared.CiCd.Tekton.TaskRun
{
    public class TektonTaskRunComponent : IComponent<TektonTaskRunComponentInput, TektonTaskRunComponentOutput>
    {
        private readonly Config _config;

        public TektonTaskRunComponent(Config config)
        {
            _config = config;
        }

        public TektonTaskRunComponentOutput Apply(TektonTaskRunComponentInput input)
        {
            _ = new ConfigFile("tekton-pipeline-task-run-hello-world", new ConfigFileArgs
            {
                File = "./Component/Shared/CiCd/Tekton/TaskRun/Yaml/hello-world-task-run.yaml",
            }, new ComponentResourceOptions { DependsOn = {input.TektonRelease, input.Namespace }});
            return new TektonTaskRunComponentOutput();
        }
    }
}