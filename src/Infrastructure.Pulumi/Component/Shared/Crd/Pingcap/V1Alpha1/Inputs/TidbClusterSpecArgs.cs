// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbClusterSpecArgs : Pulumi.ResourceArgs
    {
        [Input("acrossK8s")]
        public Input<bool>? AcrossK8s { get; set; }

        [Input("affinity")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecAffinityArgs>? Affinity { get; set; }

        [Input("annotations")]
        private InputMap<string>? _annotations;
        public InputMap<string> Annotations
        {
            get => _annotations ?? (_annotations = new InputMap<string>());
            set => _annotations = value;
        }

        [Input("cluster")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecClusterArgs>? Cluster { get; set; }

        [Input("clusterDomain")]
        public Input<string>? ClusterDomain { get; set; }

        [Input("configUpdateStrategy")]
        public Input<string>? ConfigUpdateStrategy { get; set; }

        [Input("discovery")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecDiscoveryArgs>? Discovery { get; set; }

        [Input("dnsConfig")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecDnsconfigArgs>? DnsConfig { get; set; }

        [Input("dnsPolicy")]
        public Input<string>? DnsPolicy { get; set; }

        [Input("enableDynamicConfiguration")]
        public Input<bool>? EnableDynamicConfiguration { get; set; }

        [Input("enablePVReclaim")]
        public Input<bool>? EnablePVReclaim { get; set; }

        [Input("helper")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecHelperArgs>? Helper { get; set; }

        [Input("hostNetwork")]
        public Input<bool>? HostNetwork { get; set; }

        [Input("imagePullPolicy")]
        public Input<string>? ImagePullPolicy { get; set; }

        [Input("imagePullSecrets")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecImagepullsecretsArgs>? _imagePullSecrets;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecImagepullsecretsArgs> ImagePullSecrets
        {
            get => _imagePullSecrets ?? (_imagePullSecrets = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecImagepullsecretsArgs>());
            set => _imagePullSecrets = value;
        }

        [Input("labels")]
        private InputMap<string>? _labels;
        public InputMap<string> Labels
        {
            get => _labels ?? (_labels = new InputMap<string>());
            set => _labels = value;
        }

        [Input("nodeSelector")]
        private InputMap<string>? _nodeSelector;
        public InputMap<string> NodeSelector
        {
            get => _nodeSelector ?? (_nodeSelector = new InputMap<string>());
            set => _nodeSelector = value;
        }

        [Input("paused")]
        public Input<bool>? Paused { get; set; }

        [Input("pd")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecPdArgs>? Pd { get; set; }

        [Input("pdAddresses")]
        private InputList<string>? _pdAddresses;
        public InputList<string> PdAddresses
        {
            get => _pdAddresses ?? (_pdAddresses = new InputList<string>());
            set => _pdAddresses = value;
        }

        [Input("podManagementPolicy")]
        public Input<string>? PodManagementPolicy { get; set; }

        [Input("podSecurityContext")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecPodsecuritycontextArgs>? PodSecurityContext { get; set; }

        [Input("priorityClassName")]
        public Input<string>? PriorityClassName { get; set; }

        [Input("pump")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecPumpArgs>? Pump { get; set; }

        [Input("pvReclaimPolicy")]
        public Input<string>? PvReclaimPolicy { get; set; }

        [Input("schedulerName")]
        public Input<string>? SchedulerName { get; set; }

        [Input("serviceAccount")]
        public Input<string>? ServiceAccount { get; set; }

        [Input("services")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecServicesArgs>? _services;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecServicesArgs> Services
        {
            get => _services ?? (_services = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecServicesArgs>());
            set => _services = value;
        }

        [Input("statefulSetUpdateStrategy")]
        public Input<string>? StatefulSetUpdateStrategy { get; set; }

        [Input("suspendAction")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecSuspendactionArgs>? SuspendAction { get; set; }

        [Input("ticdc")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTicdcArgs>? Ticdc { get; set; }

        [Input("tidb")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTidbArgs>? Tidb { get; set; }

        [Input("tiflash")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashArgs>? Tiflash { get; set; }

        [Input("tikv")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTikvArgs>? Tikv { get; set; }

        [Input("timezone")]
        public Input<string>? Timezone { get; set; }

        [Input("tlsCluster")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTlsclusterArgs>? TlsCluster { get; set; }

        [Input("tolerations")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTolerationsArgs>? _tolerations;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTolerationsArgs> Tolerations
        {
            get => _tolerations ?? (_tolerations = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTolerationsArgs>());
            set => _tolerations = value;
        }

        [Input("topologySpreadConstraints")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTopologyspreadconstraintsArgs>? _topologySpreadConstraints;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTopologyspreadconstraintsArgs> TopologySpreadConstraints
        {
            get => _topologySpreadConstraints ?? (_topologySpreadConstraints = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTopologyspreadconstraintsArgs>());
            set => _topologySpreadConstraints = value;
        }

        [Input("version")]
        public Input<string>? Version { get; set; }

        public TidbClusterSpecArgs()
        {
            ImagePullPolicy = "IfNotPresent";
            PvReclaimPolicy = "Retain";
        }
    }
}