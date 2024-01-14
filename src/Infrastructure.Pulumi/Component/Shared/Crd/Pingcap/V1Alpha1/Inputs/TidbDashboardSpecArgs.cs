// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbDashboardSpecArgs : global::Pulumi.ResourceArgs
    {
        [Input("additionalContainers")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbDashboardSpecAdditionalContainersArgs>? _additionalContainers;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbDashboardSpecAdditionalContainersArgs> AdditionalContainers
        {
            get => _additionalContainers ?? (_additionalContainers = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbDashboardSpecAdditionalContainersArgs>());
            set => _additionalContainers = value;
        }

        [Input("additionalVolumeMounts")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbDashboardSpecAdditionalVolumeMountsArgs>? _additionalVolumeMounts;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbDashboardSpecAdditionalVolumeMountsArgs> AdditionalVolumeMounts
        {
            get => _additionalVolumeMounts ?? (_additionalVolumeMounts = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbDashboardSpecAdditionalVolumeMountsArgs>());
            set => _additionalVolumeMounts = value;
        }

        [Input("additionalVolumes")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbDashboardSpecAdditionalVolumesArgs>? _additionalVolumes;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbDashboardSpecAdditionalVolumesArgs> AdditionalVolumes
        {
            get => _additionalVolumes ?? (_additionalVolumes = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbDashboardSpecAdditionalVolumesArgs>());
            set => _additionalVolumes = value;
        }

        [Input("affinity")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbDashboardSpecAffinityArgs>? Affinity { get; set; }

        [Input("annotations")]
        private InputMap<string>? _annotations;
        public InputMap<string> Annotations
        {
            get => _annotations ?? (_annotations = new InputMap<string>());
            set => _annotations = value;
        }

        [Input("baseImage")]
        public Input<string>? BaseImage { get; set; }

        [Input("clusters", required: true)]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbDashboardSpecClustersArgs>? _clusters;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbDashboardSpecClustersArgs> Clusters
        {
            get => _clusters ?? (_clusters = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbDashboardSpecClustersArgs>());
            set => _clusters = value;
        }

        [Input("configUpdateStrategy")]
        public Input<string>? ConfigUpdateStrategy { get; set; }

        [Input("dnsConfig")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbDashboardSpecDnsConfigArgs>? DnsConfig { get; set; }

        [Input("dnsPolicy")]
        public Input<string>? DnsPolicy { get; set; }

        [Input("env")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbDashboardSpecEnvArgs>? _env;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbDashboardSpecEnvArgs> Env
        {
            get => _env ?? (_env = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbDashboardSpecEnvArgs>());
            set => _env = value;
        }

        [Input("envFrom")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbDashboardSpecEnvFromArgs>? _envFrom;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbDashboardSpecEnvFromArgs> EnvFrom
        {
            get => _envFrom ?? (_envFrom = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbDashboardSpecEnvFromArgs>());
            set => _envFrom = value;
        }

        [Input("experimental")]
        public Input<bool>? Experimental { get; set; }

        [Input("hostNetwork")]
        public Input<bool>? HostNetwork { get; set; }

        [Input("image")]
        public Input<string>? Image { get; set; }

        [Input("imagePullPolicy")]
        public Input<string>? ImagePullPolicy { get; set; }

        [Input("imagePullSecrets")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbDashboardSpecImagePullSecretsArgs>? _imagePullSecrets;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbDashboardSpecImagePullSecretsArgs> ImagePullSecrets
        {
            get => _imagePullSecrets ?? (_imagePullSecrets = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbDashboardSpecImagePullSecretsArgs>());
            set => _imagePullSecrets = value;
        }

        [Input("initContainers")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbDashboardSpecInitContainersArgs>? _initContainers;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbDashboardSpecInitContainersArgs> InitContainers
        {
            get => _initContainers ?? (_initContainers = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbDashboardSpecInitContainersArgs>());
            set => _initContainers = value;
        }

        [Input("labels")]
        private InputMap<string>? _labels;
        public InputMap<string> Labels
        {
            get => _labels ?? (_labels = new InputMap<string>());
            set => _labels = value;
        }

        [Input("limits")]
        private InputMap<Union<int, string>>? _limits;
        public InputMap<Union<int, string>> Limits
        {
            get => _limits ?? (_limits = new InputMap<Union<int, string>>());
            set => _limits = value;
        }

        [Input("nodeSelector")]
        private InputMap<string>? _nodeSelector;
        public InputMap<string> NodeSelector
        {
            get => _nodeSelector ?? (_nodeSelector = new InputMap<string>());
            set => _nodeSelector = value;
        }

        [Input("pathPrefix")]
        public Input<string>? PathPrefix { get; set; }

        [Input("podManagementPolicy")]
        public Input<string>? PodManagementPolicy { get; set; }

        [Input("podSecurityContext")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbDashboardSpecPodSecurityContextArgs>? PodSecurityContext { get; set; }

        [Input("priorityClassName")]
        public Input<string>? PriorityClassName { get; set; }

        [Input("pvReclaimPolicy")]
        public Input<string>? PvReclaimPolicy { get; set; }

        [Input("readinessProbe")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbDashboardSpecReadinessProbeArgs>? ReadinessProbe { get; set; }

        [Input("requests")]
        private InputMap<Union<int, string>>? _requests;
        public InputMap<Union<int, string>> Requests
        {
            get => _requests ?? (_requests = new InputMap<Union<int, string>>());
            set => _requests = value;
        }

        [Input("schedulerName")]
        public Input<string>? SchedulerName { get; set; }

        [Input("service")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbDashboardSpecServiceArgs>? Service { get; set; }

        [Input("statefulSetUpdateStrategy")]
        public Input<string>? StatefulSetUpdateStrategy { get; set; }

        [Input("storageClassName")]
        public Input<string>? StorageClassName { get; set; }

        [Input("storageVolumes")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbDashboardSpecStorageVolumesArgs>? _storageVolumes;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbDashboardSpecStorageVolumesArgs> StorageVolumes
        {
            get => _storageVolumes ?? (_storageVolumes = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbDashboardSpecStorageVolumesArgs>());
            set => _storageVolumes = value;
        }

        [Input("suspendAction")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbDashboardSpecSuspendActionArgs>? SuspendAction { get; set; }

        [Input("telemetry")]
        public Input<bool>? Telemetry { get; set; }

        [Input("terminationGracePeriodSeconds")]
        public Input<int>? TerminationGracePeriodSeconds { get; set; }

        [Input("tolerations")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbDashboardSpecTolerationsArgs>? _tolerations;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbDashboardSpecTolerationsArgs> Tolerations
        {
            get => _tolerations ?? (_tolerations = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbDashboardSpecTolerationsArgs>());
            set => _tolerations = value;
        }

        [Input("topologySpreadConstraints")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbDashboardSpecTopologySpreadConstraintsArgs>? _topologySpreadConstraints;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbDashboardSpecTopologySpreadConstraintsArgs> TopologySpreadConstraints
        {
            get => _topologySpreadConstraints ?? (_topologySpreadConstraints = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbDashboardSpecTopologySpreadConstraintsArgs>());
            set => _topologySpreadConstraints = value;
        }

        [Input("version")]
        public Input<string>? Version { get; set; }

        public TidbDashboardSpecArgs()
        {
            BaseImage = "pingcap/tidb-dashboard";
            PvReclaimPolicy = "Retain";
        }
        public static new TidbDashboardSpecArgs Empty => new TidbDashboardSpecArgs();
    }
}
