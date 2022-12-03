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
    public sealed class DMClusterSpecWorker
    {
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalcontainers> AdditionalContainers;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalvolumemounts> AdditionalVolumeMounts;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalvolumes> AdditionalVolumes;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAffinity Affinity;
        public readonly ImmutableDictionary<string, string> Annotations;
        public readonly string BaseImage;
        public readonly ImmutableDictionary<string, object> Config;
        public readonly string ConfigUpdateStrategy;
        public readonly string DataSubDir;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerDnsconfig DnsConfig;
        public readonly string DnsPolicy;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerEnv> Env;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerEnvfrom> EnvFrom;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerFailover Failover;
        public readonly bool HostNetwork;
        public readonly string Image;
        public readonly string ImagePullPolicy;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerImagepullsecrets> ImagePullSecrets;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerInitcontainers> InitContainers;
        public readonly ImmutableDictionary<string, string> Labels;
        public readonly ImmutableDictionary<string, Union<int, string>> Limits;
        public readonly int MaxFailoverCount;
        public readonly ImmutableDictionary<string, string> NodeSelector;
        public readonly string PodManagementPolicy;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerPodsecuritycontext PodSecurityContext;
        public readonly string PriorityClassName;
        public readonly bool RecoverFailover;
        public readonly int Replicas;
        public readonly ImmutableDictionary<string, Union<int, string>> Requests;
        public readonly string SchedulerName;
        public readonly string StatefulSetUpdateStrategy;
        public readonly string StorageClassName;
        public readonly string StorageSize;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerSuspendaction SuspendAction;
        public readonly int TerminationGracePeriodSeconds;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerTolerations> Tolerations;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerTopologyspreadconstraints> TopologySpreadConstraints;
        public readonly string Version;

        [OutputConstructor]
        private DMClusterSpecWorker(
            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalcontainers> additionalContainers,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalvolumemounts> additionalVolumeMounts,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalvolumes> additionalVolumes,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAffinity affinity,

            ImmutableDictionary<string, string> annotations,

            string baseImage,

            ImmutableDictionary<string, object> config,

            string configUpdateStrategy,

            string dataSubDir,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerDnsconfig dnsConfig,

            string dnsPolicy,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerEnv> env,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerEnvfrom> envFrom,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerFailover failover,

            bool hostNetwork,

            string image,

            string imagePullPolicy,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerImagepullsecrets> imagePullSecrets,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerInitcontainers> initContainers,

            ImmutableDictionary<string, string> labels,

            ImmutableDictionary<string, Union<int, string>> limits,

            int maxFailoverCount,

            ImmutableDictionary<string, string> nodeSelector,

            string podManagementPolicy,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerPodsecuritycontext podSecurityContext,

            string priorityClassName,

            bool recoverFailover,

            int replicas,

            ImmutableDictionary<string, Union<int, string>> requests,

            string schedulerName,

            string statefulSetUpdateStrategy,

            string storageClassName,

            string storageSize,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerSuspendaction suspendAction,

            int terminationGracePeriodSeconds,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerTolerations> tolerations,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerTopologyspreadconstraints> topologySpreadConstraints,

            string version)
        {
            AdditionalContainers = additionalContainers;
            AdditionalVolumeMounts = additionalVolumeMounts;
            AdditionalVolumes = additionalVolumes;
            Affinity = affinity;
            Annotations = annotations;
            BaseImage = baseImage;
            Config = config;
            ConfigUpdateStrategy = configUpdateStrategy;
            DataSubDir = dataSubDir;
            DnsConfig = dnsConfig;
            DnsPolicy = dnsPolicy;
            Env = env;
            EnvFrom = envFrom;
            Failover = failover;
            HostNetwork = hostNetwork;
            Image = image;
            ImagePullPolicy = imagePullPolicy;
            ImagePullSecrets = imagePullSecrets;
            InitContainers = initContainers;
            Labels = labels;
            Limits = limits;
            MaxFailoverCount = maxFailoverCount;
            NodeSelector = nodeSelector;
            PodManagementPolicy = podManagementPolicy;
            PodSecurityContext = podSecurityContext;
            PriorityClassName = priorityClassName;
            RecoverFailover = recoverFailover;
            Replicas = replicas;
            Requests = requests;
            SchedulerName = schedulerName;
            StatefulSetUpdateStrategy = statefulSetUpdateStrategy;
            StorageClassName = storageClassName;
            StorageSize = storageSize;
            SuspendAction = suspendAction;
            TerminationGracePeriodSeconds = terminationGracePeriodSeconds;
            Tolerations = tolerations;
            TopologySpreadConstraints = topologySpreadConstraints;
            Version = version;
        }
    }
}