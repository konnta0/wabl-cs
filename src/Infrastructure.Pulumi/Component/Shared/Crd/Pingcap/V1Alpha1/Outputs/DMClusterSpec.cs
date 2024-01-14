// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1
{

    [OutputType]
    public sealed class DMClusterSpec
    {
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecAffinity Affinity;
        public readonly ImmutableDictionary<string, string> Annotations;
        public readonly string ConfigUpdateStrategy;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecDiscovery Discovery;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecDnsConfig DnsConfig;
        public readonly string DnsPolicy;
        public readonly bool EnablePVReclaim;
        public readonly bool HostNetwork;
        public readonly string ImagePullPolicy;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecImagePullSecrets> ImagePullSecrets;
        public readonly ImmutableDictionary<string, string> Labels;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecMaster Master;
        public readonly ImmutableDictionary<string, string> NodeSelector;
        public readonly bool Paused;
        public readonly string PodManagementPolicy;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecPodSecurityContext PodSecurityContext;
        public readonly string PriorityClassName;
        public readonly string PvReclaimPolicy;
        public readonly string SchedulerName;
        public readonly string StatefulSetUpdateStrategy;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecSuspendAction SuspendAction;
        public readonly string Timezone;
        public readonly ImmutableArray<string> TlsClientSecretNames;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecTlsCluster TlsCluster;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecTolerations> Tolerations;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecTopologySpreadConstraints> TopologySpreadConstraints;
        public readonly string Version;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorker Worker;

        [OutputConstructor]
        private DMClusterSpec(
            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecAffinity affinity,

            ImmutableDictionary<string, string> annotations,

            string configUpdateStrategy,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecDiscovery discovery,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecDnsConfig dnsConfig,

            string dnsPolicy,

            bool enablePVReclaim,

            bool hostNetwork,

            string imagePullPolicy,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecImagePullSecrets> imagePullSecrets,

            ImmutableDictionary<string, string> labels,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecMaster master,

            ImmutableDictionary<string, string> nodeSelector,

            bool paused,

            string podManagementPolicy,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecPodSecurityContext podSecurityContext,

            string priorityClassName,

            string pvReclaimPolicy,

            string schedulerName,

            string statefulSetUpdateStrategy,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecSuspendAction suspendAction,

            string timezone,

            ImmutableArray<string> tlsClientSecretNames,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecTlsCluster tlsCluster,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecTolerations> tolerations,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecTopologySpreadConstraints> topologySpreadConstraints,

            string version,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorker worker)
        {
            Affinity = affinity;
            Annotations = annotations;
            ConfigUpdateStrategy = configUpdateStrategy;
            Discovery = discovery;
            DnsConfig = dnsConfig;
            DnsPolicy = dnsPolicy;
            EnablePVReclaim = enablePVReclaim;
            HostNetwork = hostNetwork;
            ImagePullPolicy = imagePullPolicy;
            ImagePullSecrets = imagePullSecrets;
            Labels = labels;
            Master = master;
            NodeSelector = nodeSelector;
            Paused = paused;
            PodManagementPolicy = podManagementPolicy;
            PodSecurityContext = podSecurityContext;
            PriorityClassName = priorityClassName;
            PvReclaimPolicy = pvReclaimPolicy;
            SchedulerName = schedulerName;
            StatefulSetUpdateStrategy = statefulSetUpdateStrategy;
            SuspendAction = suspendAction;
            Timezone = timezone;
            TlsClientSecretNames = tlsClientSecretNames;
            TlsCluster = tlsCluster;
            Tolerations = tolerations;
            TopologySpreadConstraints = topologySpreadConstraints;
            Version = version;
            Worker = worker;
        }
    }
}
