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
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecGcs Gcs;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecImagepullsecrets> ImagePullSecrets;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocal Local;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecPodsecuritycontext PodSecurityContext;
        public readonly string PriorityClassName;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecResources Resources;
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

        [OutputConstructor]
        private RestoreSpec(
            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecAffinity affinity,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecAzblob azblob,

            string backupType,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecBr br,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecEnv> env,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecGcs gcs,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecImagepullsecrets> imagePullSecrets,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocal local,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecPodsecuritycontext podSecurityContext,

            string priorityClassName,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecResources resources,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecS3 s3,

            string serviceAccount,

            string storageClassName,

            string storageSize,

            ImmutableArray<string> tableFilter,

            string tikvGCLifeTime,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecTo to,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecTolerations> tolerations,

            string toolImage,

            bool useKMS)
        {
            Affinity = affinity;
            Azblob = azblob;
            BackupType = backupType;
            Br = br;
            Env = env;
            Gcs = gcs;
            ImagePullSecrets = imagePullSecrets;
            Local = local;
            PodSecurityContext = podSecurityContext;
            PriorityClassName = priorityClassName;
            Resources = resources;
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
        }
    }
}