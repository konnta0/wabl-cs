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
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecAdditionalContainers> AdditionalContainers;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecAdditionalVolumeMounts> AdditionalVolumeMounts;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecAdditionalVolumes> AdditionalVolumes;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecAffinity Affinity;
        public readonly ImmutableDictionary<string, string> Annotations;
        public readonly string ClusterDomain;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecClusters> Clusters;
        public readonly string ConfigUpdateStrategy;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecDnsConfig DnsConfig;
        public readonly string DnsPolicy;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecEnv> Env;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecEnvFrom> EnvFrom;
        public readonly bool HostNetwork;
        public readonly string Image;
        public readonly string ImagePullPolicy;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecImagePullSecrets> ImagePullSecrets;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecInitContainers> InitContainers;
        public readonly ImmutableDictionary<string, string> Labels;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecNgMonitoring NgMonitoring;
        public readonly ImmutableDictionary<string, string> NodeSelector;
        public readonly bool Paused;
        public readonly string PodManagementPolicy;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecPodSecurityContext PodSecurityContext;
        public readonly string PriorityClassName;
        public readonly string PvReclaimPolicy;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecReadinessProbe ReadinessProbe;
        public readonly string SchedulerName;
        public readonly string StatefulSetUpdateStrategy;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecSuspendAction SuspendAction;
        public readonly int TerminationGracePeriodSeconds;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecTolerations> Tolerations;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecTopologySpreadConstraints> TopologySpreadConstraints;
        public readonly string Version;

        [OutputConstructor]
        private TidbNGMonitoringSpec(
            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecAdditionalContainers> additionalContainers,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecAdditionalVolumeMounts> additionalVolumeMounts,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecAdditionalVolumes> additionalVolumes,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecAffinity affinity,

            ImmutableDictionary<string, string> annotations,

            string clusterDomain,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecClusters> clusters,

            string configUpdateStrategy,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecDnsConfig dnsConfig,

            string dnsPolicy,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecEnv> env,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecEnvFrom> envFrom,

            bool hostNetwork,

            string image,

            string imagePullPolicy,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecImagePullSecrets> imagePullSecrets,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecInitContainers> initContainers,

            ImmutableDictionary<string, string> labels,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecNgMonitoring ngMonitoring,

            ImmutableDictionary<string, string> nodeSelector,

            bool paused,

            string podManagementPolicy,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecPodSecurityContext podSecurityContext,

            string priorityClassName,

            string pvReclaimPolicy,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecReadinessProbe readinessProbe,

            string schedulerName,

            string statefulSetUpdateStrategy,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecSuspendAction suspendAction,

            int terminationGracePeriodSeconds,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecTolerations> tolerations,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecTopologySpreadConstraints> topologySpreadConstraints,

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
            ReadinessProbe = readinessProbe;
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
