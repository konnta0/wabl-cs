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
    public sealed class BackupScheduleSpecLogBackupTemplateLocalVolumeEphemeral
    {
        public readonly bool ReadOnly;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecLogBackupTemplateLocalVolumeEphemeralVolumeClaimTemplate VolumeClaimTemplate;

        [OutputConstructor]
        private BackupScheduleSpecLogBackupTemplateLocalVolumeEphemeral(
            bool readOnly,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecLogBackupTemplateLocalVolumeEphemeralVolumeClaimTemplate volumeClaimTemplate)
        {
            ReadOnly = readOnly;
            VolumeClaimTemplate = volumeClaimTemplate;
        }
    }
}
