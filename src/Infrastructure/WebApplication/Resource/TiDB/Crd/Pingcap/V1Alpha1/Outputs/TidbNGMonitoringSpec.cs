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
    public sealed class TidbNGMonitoringSpec
    {
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecAdditionalcontainers> AdditionalContainers;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecAdditionalvolumemounts> AdditionalVolumeMounts;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecAdditionalvolumes> AdditionalVolumes;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecAffinity Affinity;
        public readonly ImmutableDictionary<string, string> Annotations;
        public readonly string ClusterDomain;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecClusters> Clusters;
        public readonly string ConfigUpdateStrategy;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecDnsconfig DnsConfig;
        public readonly string DnsPolicy;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecEnv> Env;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecEnvfrom> EnvFrom;
        public readonly bool HostNetwork;
        public readonly string Image;
        public readonly string ImagePullPolicy;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecImagepullsecrets> ImagePullSecrets;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecInitcontainers> InitContainers;
        public readonly ImmutableDictionary<string, string> Labels;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecNgmonitoring NgMonitoring;
        public readonly ImmutableDictionary<string, string> NodeSelector;
        public readonly bool Paused;
        public readonly string PodManagementPolicy;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecPodsecuritycontext PodSecurityContext;
        public readonly string PriorityClassName;
        public readonly string PvReclaimPolicy;
        public readonly string SchedulerName;
        public readonly string StatefulSetUpdateStrategy;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecSuspendaction SuspendAction;
        public readonly int TerminationGracePeriodSeconds;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecTolerations> Tolerations;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecTopologyspreadconstraints> TopologySpreadConstraints;
        public readonly string Version;

        [OutputConstructor]
        private TidbNGMonitoringSpec(
            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecAdditionalcontainers> additionalContainers,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecAdditionalvolumemounts> additionalVolumeMounts,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecAdditionalvolumes> additionalVolumes,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecAffinity affinity,

            ImmutableDictionary<string, string> annotations,

            string clusterDomain,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecClusters> clusters,

            string configUpdateStrategy,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecDnsconfig dnsConfig,

            string dnsPolicy,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecEnv> env,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecEnvfrom> envFrom,

            bool hostNetwork,

            string image,

            string imagePullPolicy,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecImagepullsecrets> imagePullSecrets,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecInitcontainers> initContainers,

            ImmutableDictionary<string, string> labels,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecNgmonitoring ngMonitoring,

            ImmutableDictionary<string, string> nodeSelector,

            bool paused,

            string podManagementPolicy,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecPodsecuritycontext podSecurityContext,

            string priorityClassName,

            string pvReclaimPolicy,

            string schedulerName,

            string statefulSetUpdateStrategy,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecSuspendaction suspendAction,

            int terminationGracePeriodSeconds,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecTolerations> tolerations,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecTopologyspreadconstraints> topologySpreadConstraints,

            string version)
        {
            AdditionalContainers = additionalContainers;
            AdditionalVolumeMounts = additionalVolumeMounts;
            AdditionalVolumes = additionalVolumes;
            Affinity = affinity;
            Annotations = annotations;
            ClusterDomain = clusterDomain;
            Clusters = clusters;
            ConfigUpdateStrategy = configUpdateStrategy;
            DnsConfig = dnsConfig;
            DnsPolicy = dnsPolicy;
            Env = env;
            EnvFrom = envFrom;
            HostNetwork = hostNetwork;
            Image = image;
            ImagePullPolicy = imagePullPolicy;
            ImagePullSecrets = imagePullSecrets;
            InitContainers = initContainers;
            Labels = labels;
            NgMonitoring = ngMonitoring;
            NodeSelector = nodeSelector;
            Paused = paused;
            PodManagementPolicy = podManagementPolicy;
            PodSecurityContext = podSecurityContext;
            PriorityClassName = priorityClassName;
            PvReclaimPolicy = pvReclaimPolicy;
            SchedulerName = schedulerName;
            StatefulSetUpdateStrategy = statefulSetUpdateStrategy;
            SuspendAction = suspendAction;
            TerminationGracePeriodSeconds = terminationGracePeriodSeconds;
            Tolerations = tolerations;
            TopologySpreadConstraints = topologySpreadConstraints;
            Version = version;
        }
    }
}
