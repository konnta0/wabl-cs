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
    public sealed class TidbDashboardSpec
    {
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecAdditionalContainers> AdditionalContainers;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecAdditionalVolumeMounts> AdditionalVolumeMounts;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecAdditionalVolumes> AdditionalVolumes;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecAffinity Affinity;
        public readonly ImmutableDictionary<string, string> Annotations;
        public readonly string BaseImage;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecClusters> Clusters;
        public readonly string ConfigUpdateStrategy;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecDnsConfig DnsConfig;
        public readonly string DnsPolicy;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecEnv> Env;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecEnvFrom> EnvFrom;
        public readonly bool Experimental;
        public readonly bool HostNetwork;
        public readonly string Image;
        public readonly string ImagePullPolicy;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecImagePullSecrets> ImagePullSecrets;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecInitContainers> InitContainers;
        public readonly ImmutableDictionary<string, string> Labels;
        public readonly ImmutableDictionary<string, Union<int, string>> Limits;
        public readonly ImmutableDictionary<string, string> NodeSelector;
        public readonly string PathPrefix;
        public readonly string PodManagementPolicy;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecPodSecurityContext PodSecurityContext;
        public readonly string PriorityClassName;
        public readonly string PvReclaimPolicy;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecReadinessProbe ReadinessProbe;
        public readonly ImmutableDictionary<string, Union<int, string>> Requests;
        public readonly string SchedulerName;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecService Service;
        public readonly string StatefulSetUpdateStrategy;
        public readonly string StorageClassName;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecStorageVolumes> StorageVolumes;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecSuspendAction SuspendAction;
        public readonly bool Telemetry;
        public readonly int TerminationGracePeriodSeconds;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecTolerations> Tolerations;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecTopologySpreadConstraints> TopologySpreadConstraints;
        public readonly string Version;

        [OutputConstructor]
        private TidbDashboardSpec(
            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecAdditionalContainers> additionalContainers,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecAdditionalVolumeMounts> additionalVolumeMounts,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecAdditionalVolumes> additionalVolumes,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecAffinity affinity,

            ImmutableDictionary<string, string> annotations,

            string baseImage,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecClusters> clusters,

            string configUpdateStrategy,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecDnsConfig dnsConfig,

            string dnsPolicy,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecEnv> env,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecEnvFrom> envFrom,

            bool experimental,

            bool hostNetwork,

            string image,

            string imagePullPolicy,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecImagePullSecrets> imagePullSecrets,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecInitContainers> initContainers,

            ImmutableDictionary<string, string> labels,

            ImmutableDictionary<string, Union<int, string>> limits,

            ImmutableDictionary<string, string> nodeSelector,

            string pathPrefix,

            string podManagementPolicy,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecPodSecurityContext podSecurityContext,

            string priorityClassName,

            string pvReclaimPolicy,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecReadinessProbe readinessProbe,

            ImmutableDictionary<string, Union<int, string>> requests,

            string schedulerName,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecService service,

            string statefulSetUpdateStrategy,

            string storageClassName,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecStorageVolumes> storageVolumes,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecSuspendAction suspendAction,

            bool telemetry,

            int terminationGracePeriodSeconds,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecTolerations> tolerations,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecTopologySpreadConstraints> topologySpreadConstraints,

            string version)
        {
            AdditionalContainers = additionalContainers;
            AdditionalVolumeMounts = additionalVolumeMounts;
            AdditionalVolumes = additionalVolumes;
            Affinity = affinity;
            Annotations = annotations;
            BaseImage = baseImage;
            Clusters = clusters;
            ConfigUpdateStrategy = configUpdateStrategy;
            DnsConfig = dnsConfig;
            DnsPolicy = dnsPolicy;
            Env = env;
            EnvFrom = envFrom;
            Experimental = experimental;
            HostNetwork = hostNetwork;
            Image = image;
            ImagePullPolicy = imagePullPolicy;
            ImagePullSecrets = imagePullSecrets;
            InitContainers = initContainers;
            Labels = labels;
            Limits = limits;
            NodeSelector = nodeSelector;
            PathPrefix = pathPrefix;
            PodManagementPolicy = podManagementPolicy;
            PodSecurityContext = podSecurityContext;
            PriorityClassName = priorityClassName;
            PvReclaimPolicy = pvReclaimPolicy;
            ReadinessProbe = readinessProbe;
            Requests = requests;
            SchedulerName = schedulerName;
            Service = service;
            StatefulSetUpdateStrategy = statefulSetUpdateStrategy;
            StorageClassName = storageClassName;
            StorageVolumes = storageVolumes;
            SuspendAction = suspendAction;
            Telemetry = telemetry;
            TerminationGracePeriodSeconds = terminationGracePeriodSeconds;
            Tolerations = tolerations;
            TopologySpreadConstraints = topologySpreadConstraints;
            Version = version;
        }
    }
}
