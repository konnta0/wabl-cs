using System.Collections.Immutable;
using Pulumi;
using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Types.Inputs.Core.V1;
using Pulumi.Kubernetes.Types.Inputs.Meta.V1;
using Pulumi.Kubernetes.Yaml;

namespace Infrastructure.Component.Shared.CiCd.Spinnaker
{
    public class SpinnakerComponent : IComponent<SpinnakerComponentInput, SpinnakerComponentOutput>
    {
        private readonly Config _config;

        public SpinnakerComponent(Config config)
        {
            _config = config;
        }

        public SpinnakerComponentOutput Apply(SpinnakerComponentInput input)
        {
            new ConfigFile("spinnaker-accounts-crd", new ConfigFileArgs
            {
                File =
                    "CiCd/Component/Spinnaker/Yaml/spinnaker-operator/deploy/crds/spinnaker.io_spinnakeraccounts_crd.yaml"
            }).Ready();

            new ConfigFile("spinnaker-services-crd", new ConfigFileArgs
            {
                File =
                    "CiCd/Component/Spinnaker/Yaml/spinnaker-operator/deploy/crds/spinnaker.io_spinnakerservices_crd.yaml"
            }).Ready();

            var ns = new Namespace("cicd-namespace", new NamespaceArgs
            {
                Metadata = new ObjectMetaArgs
                {
                    Name = "cicd"
                }
            });

            var components = new []
            {
                "deployment",
                "role",
                "role_binding",
                "service_account"
            };

            foreach (var component in components)
            {
                new ConfigFile($"spinnaker-operator-basic-{component}", new ConfigFileArgs
                {
                    File =
                        $"CiCd/Component/Spinnaker/Yaml/spinnaker-operator/deploy/operator/basic/{component}.yaml",
                    Transformations =
                    {
                        (ImmutableDictionary<string, object> obj, CustomResourceOptions opts) =>
                        {
                            var metadata = (ImmutableDictionary<string, object>)obj["metadata"];
                            if (!metadata.ContainsKey("namespace")) return obj;
                            var @namespace = ns.Metadata.Apply(x => x.Namespace);
                            return obj.SetItem("metadata", metadata.SetItem("namespace", @namespace));
                        }
                    }
                }).Ready();
            }

            foreach (var component in components)
            {
                new ConfigFile($"spinnaker-operator-cluster-{component}", new ConfigFileArgs
                {
                    File =
                        $"CiCd/Component/Spinnaker/Yaml/spinnaker-operator/deploy/operator/cluster/{component}.yaml",
                    Transformations =
                    {
                        (ImmutableDictionary<string, object> obj, CustomResourceOptions opts) =>
                        {
                            var metadata = (ImmutableDictionary<string, object>)obj["metadata"];
                            if (!metadata.ContainsKey("namespace")) return obj;
                            var @namespace = ns.Metadata.Apply(x => x.Namespace);
                            return obj.SetItem("metadata", metadata.SetItem("namespace", @namespace));
                        }
                    }
                }).Ready();
            }

            //_minIoResource.Apply();

            // TODO: change the config.persistentStorage
            new ConfigFile($"spinnaker-operator-cluster-spinnakerservice", new ConfigFileArgs
            {
                File =
                    $"CiCd/Component/Spinnaker/Yaml/spinnaker-operator/deploy/spinnaker/basic/spinnakerservice.yml",
                Transformations =
                {
                    (ImmutableDictionary<string, object> obj, CustomResourceOptions opts) =>
                    {
                        var metadata = (ImmutableDictionary<string, object>)obj["metadata"];
                        if (!metadata.ContainsKey("namespace")) return obj;
                        var @namespace = ns.Metadata.Apply(x => x.Namespace);
                        return obj.SetItem("metadata", metadata.SetItem("namespace", @namespace));
                    }
                }
            }).Ready();


            // var release = new Release("spinnaker-release", new ReleaseArgs
            // {
            //     Namespace = ns.Metadata.Apply(x => x.Name),
            //     Chart = "CI_CD/Resource/Spinnaker/Yaml/spinnaker-operator/helm/Chart.yaml",
            // });
            return new SpinnakerComponentOutput();
        }
    }
}