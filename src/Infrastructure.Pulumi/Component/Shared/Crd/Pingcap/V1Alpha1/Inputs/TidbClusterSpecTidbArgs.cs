// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbClusterSpecTidbArgs : global::Pulumi.ResourceArgs
    {
        [Input("additionalContainers")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTidbAdditionalContainersArgs>? _additionalContainers;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTidbAdditionalContainersArgs> AdditionalContainers
        {
            get => _additionalContainers ?? (_additionalContainers = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTidbAdditionalContainersArgs>());
            set => _additionalContainers = value;
        }

        [Input("additionalVolumeMounts")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTidbAdditionalVolumeMountsArgs>? _additionalVolumeMounts;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTidbAdditionalVolumeMountsArgs> AdditionalVolumeMounts
        {
            get => _additionalVolumeMounts ?? (_additionalVolumeMounts = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTidbAdditionalVolumeMountsArgs>());
            set => _additionalVolumeMounts = value;
        }

        [Input("additionalVolumes")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTidbAdditionalVolumesArgs>? _additionalVolumes;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTidbAdditionalVolumesArgs> AdditionalVolumes
        {
            get => _additionalVolumes ?? (_additionalVolumes = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTidbAdditionalVolumesArgs>());
            set => _additionalVolumes = value;
        }

        [Input("affinity")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTidbAffinityArgs>? Affinity { get; set; }

        [Input("annotations")]
        private InputMap<string>? _annotations;
        public InputMap<string> Annotations
        {
            get => _annotations ?? (_annotations = new InputMap<string>());
            set => _annotations = value;
        }

        [Input("baseImage")]
        public Input<string>? BaseImage { get; set; }

        [Input("binlogEnabled")]
        public Input<bool>? BinlogEnabled { get; set; }

        [Input("bootstrapSQLConfigMapName")]
        public Input<string>? BootstrapSQLConfigMapName { get; set; }

        [Input("config")]
        private InputMap<object>? _config;
        public InputMap<object> Config
        {
            get => _config ?? (_config = new InputMap<object>());
            set => _config = value;
        }

        [Input("configUpdateStrategy")]
        public Input<string>? ConfigUpdateStrategy { get; set; }

        [Input("dnsConfig")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTidbDnsConfigArgs>? DnsConfig { get; set; }

        [Input("dnsPolicy")]
        public Input<string>? DnsPolicy { get; set; }

        [Input("env")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTidbEnvArgs>? _env;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTidbEnvArgs> Env
        {
            get => _env ?? (_env = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTidbEnvArgs>());
            set => _env = value;
        }

        [Input("envFrom")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTidbEnvFromArgs>? _envFrom;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTidbEnvFromArgs> EnvFrom
        {
            get => _envFrom ?? (_envFrom = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTidbEnvFromArgs>());
            set => _envFrom = value;
        }

        [Input("hostNetwork")]
        public Input<bool>? HostNetwork { get; set; }

        [Input("image")]
        public Input<string>? Image { get; set; }

        [Input("imagePullPolicy")]
        public Input<string>? ImagePullPolicy { get; set; }

        [Input("imagePullSecrets")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTidbImagePullSecretsArgs>? _imagePullSecrets;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTidbImagePullSecretsArgs> ImagePullSecrets
        {
            get => _imagePullSecrets ?? (_imagePullSecrets = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTidbImagePullSecretsArgs>());
            set => _imagePullSecrets = value;
        }

        [Input("initContainers")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTidbInitContainersArgs>? _initContainers;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTidbInitContainersArgs> InitContainers
        {
            get => _initContainers ?? (_initContainers = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTidbInitContainersArgs>());
            set => _initContainers = value;
        }

        [Input("initializer")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTidbInitializerArgs>? Initializer { get; set; }

        [Input("labels")]
        private InputMap<string>? _labels;
        public InputMap<string> Labels
        {
            get => _labels ?? (_labels = new InputMap<string>());
            set => _labels = value;
        }

        [Input("lifecycle")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTidbLifecycleArgs>? Lifecycle { get; set; }

        [Input("limits")]
        private InputMap<Union<int, string>>? _limits;
        public InputMap<Union<int, string>> Limits
        {
            get => _limits ?? (_limits = new InputMap<Union<int, string>>());
            set => _limits = value;
        }

        [Input("maxFailoverCount")]
        public Input<int>? MaxFailoverCount { get; set; }

        [Input("nodeSelector")]
        private InputMap<string>? _nodeSelector;
        public InputMap<string> NodeSelector
        {
            get => _nodeSelector ?? (_nodeSelector = new InputMap<string>());
            set => _nodeSelector = value;
        }

        [Input("plugins")]
        private InputList<string>? _plugins;
        public InputList<string> Plugins
        {
            get => _plugins ?? (_plugins = new InputList<string>());
            set => _plugins = value;
        }

        [Input("podManagementPolicy")]
        public Input<string>? PodManagementPolicy { get; set; }

        [Input("podSecurityContext")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTidbPodSecurityContextArgs>? PodSecurityContext { get; set; }

        [Input("priorityClassName")]
        public Input<string>? PriorityClassName { get; set; }

        [Input("readinessProbe")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTidbReadinessProbeArgs>? ReadinessProbe { get; set; }

        [Input("replicas", required: true)]
        public Input<int> Replicas { get; set; } = null!;

        [Input("requests")]
        private InputMap<Union<int, string>>? _requests;
        public InputMap<Union<int, string>> Requests
        {
            get => _requests ?? (_requests = new InputMap<Union<int, string>>());
            set => _requests = value;
        }

        [Input("schedulerName")]
        public Input<string>? SchedulerName { get; set; }

        [Input("separateSlowLog")]
        public Input<bool>? SeparateSlowLog { get; set; }

        [Input("service")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTidbServiceArgs>? Service { get; set; }

        [Input("serviceAccount")]
        public Input<string>? ServiceAccount { get; set; }

        [Input("slowLogTailer")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTidbSlowLogTailerArgs>? SlowLogTailer { get; set; }

        [Input("slowLogVolumeName")]
        public Input<string>? SlowLogVolumeName { get; set; }

        [Input("statefulSetUpdateStrategy")]
        public Input<string>? StatefulSetUpdateStrategy { get; set; }

        [Input("storageClassName")]
        public Input<string>? StorageClassName { get; set; }

        [Input("storageVolumes")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTidbStorageVolumesArgs>? _storageVolumes;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTidbStorageVolumesArgs> StorageVolumes
        {
            get => _storageVolumes ?? (_storageVolumes = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTidbStorageVolumesArgs>());
            set => _storageVolumes = value;
        }

        [Input("suspendAction")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTidbSuspendActionArgs>? SuspendAction { get; set; }

        [Input("terminationGracePeriodSeconds")]
        public Input<int>? TerminationGracePeriodSeconds { get; set; }

        [Input("tlsClient")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTidbTlsClientArgs>? TlsClient { get; set; }

        [Input("tokenBasedAuthEnabled")]
        public Input<bool>? TokenBasedAuthEnabled { get; set; }

        [Input("tolerations")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTidbTolerationsArgs>? _tolerations;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTidbTolerationsArgs> Tolerations
        {
            get => _tolerations ?? (_tolerations = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTidbTolerationsArgs>());
            set => _tolerations = value;
        }

        [Input("topologySpreadConstraints")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTidbTopologySpreadConstraintsArgs>? _topologySpreadConstraints;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTidbTopologySpreadConstraintsArgs> TopologySpreadConstraints
        {
            get => _topologySpreadConstraints ?? (_topologySpreadConstraints = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTidbTopologySpreadConstraintsArgs>());
            set => _topologySpreadConstraints = value;
        }

        [Input("version")]
        public Input<string>? Version { get; set; }

        public TidbClusterSpecTidbArgs()
        {
            BaseImage = "pingcap/tidb";
        }
        public static new TidbClusterSpecTidbArgs Empty => new TidbClusterSpecTidbArgs();
    }
}
