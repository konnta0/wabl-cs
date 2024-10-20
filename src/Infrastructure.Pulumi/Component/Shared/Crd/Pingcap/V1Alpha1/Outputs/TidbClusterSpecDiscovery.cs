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
    public sealed class TidbClusterSpecDiscovery
    {
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecDiscoveryAdditionalContainers> AdditionalContainers;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecDiscoveryAdditionalVolumeMounts> AdditionalVolumeMounts;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecDiscoveryAdditionalVolumes> AdditionalVolumes;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecDiscoveryAffinity Affinity;
        public readonly ImmutableDictionary<string, string> Annotations;
        public readonly string ConfigUpdateStrategy;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecDiscoveryDnsConfig DnsConfig;
        public readonly string DnsPolicy;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecDiscoveryEnv> Env;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecDiscoveryEnvFrom> EnvFrom;
        public readonly bool HostNetwork;
        public readonly string Image;
        public readonly string ImagePullPolicy;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecDiscoveryImagePullSecrets> ImagePullSecrets;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecDiscoveryInitContainers> InitContainers;
        public readonly ImmutableDictionary<string, string> Labels;
        public readonly ImmutableDictionary<string, Union<int, string>> Limits;
        public readonly ImmutableDictionary<string, string> NodeSelector;
        public readonly string PodManagementPolicy;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecDiscoveryPodSecurityContext PodSecurityContext;
        public readonly string PriorityClassName;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecDiscoveryReadinessProbe ReadinessProbe;
        public readonly ImmutableDictionary<string, Union<int, string>> Requests;
        public readonly string SchedulerName;
        public readonly string StatefulSetUpdateStrategy;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecDiscoverySuspendAction SuspendAction;
        public readonly int TerminationGracePeriodSeconds;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecDiscoveryTolerations> Tolerations;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecDiscoveryTopologySpreadConstraints> TopologySpreadConstraints;
        public readonly string Version;

        [OutputConstructor]
        private TidbClusterSpecDiscovery(
            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecDiscoveryAdditionalContainers> additionalContainers,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecDiscoveryAdditionalVolumeMounts> additionalVolumeMounts,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecDiscoveryAdditionalVolumes> additionalVolumes,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecDiscoveryAffinity affinity,

            ImmutableDictionary<string, string> annotations,

            string configUpdateStrategy,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecDiscoveryDnsConfig dnsConfig,

            string dnsPolicy,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecDiscoveryEnv> env,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecDiscoveryEnvFrom> envFrom,

            bool hostNetwork,

            string image,

            string imagePullPolicy,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecDiscoveryImagePullSecrets> imagePullSecrets,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecDiscoveryInitContainers> initContainers,

            ImmutableDictionary<string, string> labels,

            ImmutableDictionary<string, Union<int, string>> limits,

            ImmutableDictionary<string, string> nodeSelector,

            string podManagementPolicy,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecDiscoveryPodSecurityContext podSecurityContext,

            string priorityClassName,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecDiscoveryReadinessProbe readinessProbe,

            ImmutableDictionary<string, Union<int, string>> requests,

            string schedulerName,

            string statefulSetUpdateStrategy,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecDiscoverySuspendAction suspendAction,

            int terminationGracePeriodSeconds,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecDiscoveryTolerations> tolerations,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecDiscoveryTopologySpreadConstraints> topologySpreadConstraints,

            string version)
        {
            AdditionalContainers = additionalContainers;
            AdditionalVolumeMounts = additionalVolumeMounts;
            AdditionalVolumes = additionalVolumes;
            Affinity = affinity;
            Annotations = annotations;
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
            Limits = limits;
            NodeSelector = nodeSelector;
            PodManagementPolicy = podManagementPolicy;
            PodSecurityContext = podSecurityContext;
            PriorityClassName = priorityClassName;
            ReadinessProbe = readinessProbe;
            Requests = requests;
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
