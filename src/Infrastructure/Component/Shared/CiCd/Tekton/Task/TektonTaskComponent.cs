using Pulumi;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.Component.Shared.CiCd.Tekton.Task
{
    public class TektonTaskComponent : IComponent<TektonTaskComponentInput, TektonComponentOutput>
    {
        private readonly Config _config;

        public TektonTaskComponent(Config config)
        {
            _config = config;
        }

        public TektonComponentOutput Apply(TektonTaskComponentInput input)
        {
            var tasks = new[]
            {
                "push-image",
                "hello-world-task",
                "git-clone",
                "buildah",
                "unit-test",
                "curl",
                "kaniko",
                "create-ingress"
            };

            foreach (var task in tasks)
            {
                _ = new ConfigFile($"tekton-pipeline-task-{task}", new ConfigFileArgs
                {
                    File = $"./Component/Shared/CiCd/Tekton/Task/Yaml/{task}.yaml",
                }, new ComponentResourceOptions { DependsOn = { input.TektonRelease, input.Namespace } });
            }

            return new TektonComponentOutput();
        }
    }
}