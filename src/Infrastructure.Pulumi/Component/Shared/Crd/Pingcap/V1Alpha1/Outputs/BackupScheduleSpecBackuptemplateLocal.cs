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
    public sealed class BackupScheduleSpecBackupTemplateLocal
    {
        public readonly string Prefix;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecBackupTemplateLocalVolume Volume;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecBackupTemplateLocalVolumeMount VolumeMount;

        [OutputConstructor]
        private BackupScheduleSpecBackupTemplateLocal(
            string prefix,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecBackupTemplateLocalVolume volume,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecBackupTemplateLocalVolumeMount volumeMount)
        {
            Prefix = prefix;
            Volume = volume;
            VolumeMount = volumeMount;
        }
    }
}
