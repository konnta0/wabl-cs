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
    public sealed class BackupScheduleSpecBackupTemplateLocalVolumeEphemeralVolumeClaimTemplateSpec
    {
        public readonly ImmutableArray<string> AccessModes;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecBackupTemplateLocalVolumeEphemeralVolumeClaimTemplateSpecDataSource DataSource;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecBackupTemplateLocalVolumeEphemeralVolumeClaimTemplateSpecResources Resources;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecBackupTemplateLocalVolumeEphemeralVolumeClaimTemplateSpecSelector Selector;
        public readonly string StorageClassName;
        public readonly string VolumeMode;
        public readonly string VolumeName;

        [OutputConstructor]
        private BackupScheduleSpecBackupTemplateLocalVolumeEphemeralVolumeClaimTemplateSpec(
            ImmutableArray<string> accessModes,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecBackupTemplateLocalVolumeEphemeralVolumeClaimTemplateSpecDataSource dataSource,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecBackupTemplateLocalVolumeEphemeralVolumeClaimTemplateSpecResources resources,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecBackupTemplateLocalVolumeEphemeralVolumeClaimTemplateSpecSelector selector,

            string storageClassName,

            string volumeMode,

            string volumeName)
        {
            AccessModes = accessModes;
            DataSource = dataSource;
            Resources = resources;
            Selector = selector;
            StorageClassName = storageClassName;
            VolumeMode = volumeMode;
            VolumeName = volumeName;
        }
    }
}
