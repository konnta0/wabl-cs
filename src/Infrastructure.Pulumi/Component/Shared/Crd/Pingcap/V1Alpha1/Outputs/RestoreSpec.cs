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
    public sealed class RestoreSpec
    {
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecAffinity Affinity;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecAzblob Azblob;
        public readonly string BackupType;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecBr Br;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecEnv> Env;
        public readonly string FederalVolumeRestorePhase;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecGcs Gcs;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecImagePullSecrets> ImagePullSecrets;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocal Local;
        public readonly string LogRestoreStartTs;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecPitrFullBackupStorageProvider PitrFullBackupStorageProvider;
        public readonly string PitrRestoredTs;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecPodSecurityContext PodSecurityContext;
        public readonly string PriorityClassName;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecResources Resources;
        public readonly string RestoreMode;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecS3 S3;
        public readonly string ServiceAccount;
        public readonly string StorageClassName;
        public readonly string StorageSize;
        public readonly ImmutableArray<string> TableFilter;
        public readonly string TikvGCLifeTime;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecTo To;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecTolerations> Tolerations;
        public readonly string ToolImage;
        public readonly bool UseKMS;
        public readonly string VolumeAZ;
        public readonly string Warmup;
        public readonly string WarmupImage;
        public readonly string WarmupStrategy;

        [OutputConstructor]
        private RestoreSpec(
            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecAffinity affinity,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecAzblob azblob,

            string backupType,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecBr br,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecEnv> env,

            string federalVolumeRestorePhase,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecGcs gcs,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecImagePullSecrets> imagePullSecrets,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocal local,

            string logRestoreStartTs,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecPitrFullBackupStorageProvider pitrFullBackupStorageProvider,

            string pitrRestoredTs,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecPodSecurityContext podSecurityContext,

            string priorityClassName,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecResources resources,

            string restoreMode,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecS3 s3,

            string serviceAccount,

            string storageClassName,

            string storageSize,

            ImmutableArray<string> tableFilter,

            string tikvGCLifeTime,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecTo to,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecTolerations> tolerations,

            string toolImage,

            bool useKMS,

            string volumeAZ,

            string warmup,

            string warmupImage,

            string warmupStrategy)
        {
            Affinity = affinity;
            Azblob = azblob;
            BackupType = backupType;
            Br = br;
            Env = env;
            FederalVolumeRestorePhase = federalVolumeRestorePhase;
            Gcs = gcs;
            ImagePullSecrets = imagePullSecrets;
            Local = local;
            LogRestoreStartTs = logRestoreStartTs;
            PitrFullBackupStorageProvider = pitrFullBackupStorageProvider;
            PitrRestoredTs = pitrRestoredTs;
            PodSecurityContext = podSecurityContext;
            PriorityClassName = priorityClassName;
            Resources = resources;
            RestoreMode = restoreMode;
            S3 = s3;
            ServiceAccount = serviceAccount;
            StorageClassName = storageClassName;
            StorageSize = storageSize;
            TableFilter = tableFilter;
            TikvGCLifeTime = tikvGCLifeTime;
            To = to;
            Tolerations = tolerations;
            ToolImage = toolImage;
            UseKMS = useKMS;
            VolumeAZ = volumeAZ;
            Warmup = warmup;
            WarmupImage = warmupImage;
            WarmupStrategy = warmupStrategy;
        }
    }
}
