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
    public sealed class BackupScheduleSpecBackupTemplate
    {
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecBackupTemplateAffinity Affinity;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecBackupTemplateAzblob Azblob;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecBackupTemplateBackoffRetryPolicy BackoffRetryPolicy;
        public readonly string BackupMode;
        public readonly string BackupType;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecBackupTemplateBr Br;
        public readonly string CalcSizeLevel;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecBackupTemplateCleanOption CleanOption;
        public readonly string CleanPolicy;
        public readonly string CommitTs;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecBackupTemplateDumpling Dumpling;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecBackupTemplateEnv> Env;
        public readonly string FederalVolumeBackupPhase;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecBackupTemplateFrom From;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecBackupTemplateGcs Gcs;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecBackupTemplateImagePullSecrets> ImagePullSecrets;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecBackupTemplateLocal Local;
        public readonly bool LogStop;
        public readonly string LogTruncateUntil;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecBackupTemplatePodSecurityContext PodSecurityContext;
        public readonly string PriorityClassName;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecBackupTemplateResources Resources;
        public readonly bool ResumeGcSchedule;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecBackupTemplateS3 S3;
        public readonly string ServiceAccount;
        public readonly string StorageClassName;
        public readonly string StorageSize;
        public readonly ImmutableArray<string> TableFilter;
        public readonly string TikvGCLifeTime;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecBackupTemplateTolerations> Tolerations;
        public readonly string ToolImage;
        public readonly bool UseKMS;

        [OutputConstructor]
        private BackupScheduleSpecBackupTemplate(
            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecBackupTemplateAffinity affinity,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecBackupTemplateAzblob azblob,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecBackupTemplateBackoffRetryPolicy backoffRetryPolicy,

            string backupMode,

            string backupType,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecBackupTemplateBr br,

            string calcSizeLevel,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecBackupTemplateCleanOption cleanOption,

            string cleanPolicy,

            string commitTs,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecBackupTemplateDumpling dumpling,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecBackupTemplateEnv> env,

            string federalVolumeBackupPhase,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecBackupTemplateFrom from,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecBackupTemplateGcs gcs,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecBackupTemplateImagePullSecrets> imagePullSecrets,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecBackupTemplateLocal local,

            bool logStop,

            string logTruncateUntil,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecBackupTemplatePodSecurityContext podSecurityContext,

            string priorityClassName,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecBackupTemplateResources resources,

            bool resumeGcSchedule,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecBackupTemplateS3 s3,

            string serviceAccount,

            string storageClassName,

            string storageSize,

            ImmutableArray<string> tableFilter,

            string tikvGCLifeTime,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecBackupTemplateTolerations> tolerations,

            string toolImage,

            bool useKMS)
        {
            Affinity = affinity;
            Azblob = azblob;
            BackoffRetryPolicy = backoffRetryPolicy;
            BackupMode = backupMode;
            BackupType = backupType;
            Br = br;
            CalcSizeLevel = calcSizeLevel;
            CleanOption = cleanOption;
            CleanPolicy = cleanPolicy;
            CommitTs = commitTs;
            Dumpling = dumpling;
            Env = env;
            FederalVolumeBackupPhase = federalVolumeBackupPhase;
            From = from;
            Gcs = gcs;
            ImagePullSecrets = imagePullSecrets;
            Local = local;
            LogStop = logStop;
            LogTruncateUntil = logTruncateUntil;
            PodSecurityContext = podSecurityContext;
            PriorityClassName = priorityClassName;
            Resources = resources;
            ResumeGcSchedule = resumeGcSchedule;
            S3 = s3;
            ServiceAccount = serviceAccount;
            StorageClassName = storageClassName;
            StorageSize = storageSize;
            TableFilter = tableFilter;
            TikvGCLifeTime = tikvGCLifeTime;
            Tolerations = tolerations;
            ToolImage = toolImage;
            UseKMS = useKMS;
        }
    }
}
