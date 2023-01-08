// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class DMClusterSpecArgs : Pulumi.ResourceArgs
    {
        [Input("affinity")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecAffinityArgs>? Affinity { get; set; }

        [Input("annotations")]
        private InputMap<string>? _annotations;
        public InputMap<string> Annotations
        {
            get => _annotations ?? (_annotations = new InputMap<string>());
            set => _annotations = value;
        }

        [Input("configUpdateStrategy")]
        public Input<string>? ConfigUpdateStrategy { get; set; }

        [Input("discovery")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecDiscoveryArgs>? Discovery { get; set; }

        [Input("dnsConfig")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecDnsconfigArgs>? DnsConfig { get; set; }

        [Input("dnsPolicy")]
        public Input<string>? DnsPolicy { get; set; }

        [Input("enablePVReclaim")]
        public Input<bool>? EnablePVReclaim { get; set; }

        [Input("hostNetwork")]
        public Input<bool>? HostNetwork { get; set; }

        [Input("imagePullPolicy")]
        public Input<string>? ImagePullPolicy { get; set; }

        [Input("imagePullSecrets")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecImagepullsecretsArgs>? _imagePullSecrets;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecImagepullsecretsArgs> ImagePullSecrets
        {
            get => _imagePullSecrets ?? (_imagePullSecrets = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecImagepullsecretsArgs>());
            set => _imagePullSecrets = value;
        }

        [Input("labels")]
        private InputMap<string>? _labels;
        public InputMap<string> Labels
        {
            get => _labels ?? (_labels = new InputMap<string>());
            set => _labels = value;
        }

        [Input("master")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecMasterArgs>? Master { get; set; }

        [Input("nodeSelector")]
        private InputMap<string>? _nodeSelector;
        public InputMap<string> NodeSelector
        {
            get => _nodeSelector ?? (_nodeSelector = new InputMap<string>());
            set => _nodeSelector = value;
        }

        [Input("paused")]
        public Input<bool>? Paused { get; set; }

        [Input("podManagementPolicy")]
        public Input<string>? PodManagementPolicy { get; set; }

        [Input("podSecurityContext")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecPodsecuritycontextArgs>? PodSecurityContext { get; set; }

        [Input("priorityClassName")]
        public Input<string>? PriorityClassName { get; set; }

        [Input("pvReclaimPolicy")]
        public Input<string>? PvReclaimPolicy { get; set; }

        [Input("schedulerName")]
        public Input<string>? SchedulerName { get; set; }

        [Input("statefulSetUpdateStrategy")]
        public Input<string>? StatefulSetUpdateStrategy { get; set; }

        [Input("suspendAction")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecSuspendactionArgs>? SuspendAction { get; set; }

        [Input("timezone")]
        public Input<string>? Timezone { get; set; }

        [Input("tlsClientSecretNames")]
        private InputList<string>? _tlsClientSecretNames;
        public InputList<string> TlsClientSecretNames
        {
            get => _tlsClientSecretNames ?? (_tlsClientSecretNames = new InputList<string>());
            set => _tlsClientSecretNames = value;
        }

        [Input("tlsCluster")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecTlsclusterArgs>? TlsCluster { get; set; }

        [Input("tolerations")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecTolerationsArgs>? _tolerations;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecTolerationsArgs> Tolerations
        {
            get => _tolerations ?? (_tolerations = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecTolerationsArgs>());
            set => _tolerations = value;
        }

        [Input("topologySpreadConstraints")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecTopologyspreadconstraintsArgs>? _topologySpreadConstraints;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecTopologyspreadconstraintsArgs> TopologySpreadConstraints
        {
            get => _topologySpreadConstraints ?? (_topologySpreadConstraints = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecTopologyspreadconstraintsArgs>());
            set => _topologySpreadConstraints = value;
        }

        [Input("version")]
        public Input<string>? Version { get; set; }

        [Input("worker")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecWorkerArgs>? Worker { get; set; }

        public DMClusterSpecArgs()
        {
            ImagePullPolicy = "IfNotPresent";
            PvReclaimPolicy = "Retain";
        }
    }
}