using System.Collections.Immutable;
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
                "curl"
            };

            var ns = input.Namespace.Metadata.Apply(x => x.Name);
            ImmutableDictionary<string, object> TransformNamespace(ImmutableDictionary<string, object> obj,
                CustomResourceOptions opts)
            {
                var metadata = (ImmutableDictionary<string, object>)obj["metadata"];
                if (!metadata.ContainsKey("namespace")) return obj;
                return obj.SetItem("metadata", metadata.SetItem("namespace", ns));
            }

            foreach (var task in tasks)
            {
                _ = new ConfigFile($"tekton-pipeline-task-{task}", new ConfigFileArgs
                {
                    File = $"./Component/Shared/CiCd/Tekton/Task/Yaml/{task}.yaml",
                    Transformations =
                    {
                        TransformNamespace
                    }
                }, new ComponentResourceOptions { DependsOn = { input.Namespace } });
            }

            return new TektonComponentOutput();
        }
    }
}