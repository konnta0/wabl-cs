// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class BackupScheduleSpecLogBackupTemplateLocalArgs : global::Pulumi.ResourceArgs
    {
        [Input("prefix")]
        public Input<string>? Prefix { get; set; }

        [Input("volume", required: true)]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.BackupScheduleSpecLogBackupTemplateLocalVolumeArgs> Volume { get; set; } = null!;

        [Input("volumeMount", required: true)]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.BackupScheduleSpecLogBackupTemplateLocalVolumeMountArgs> VolumeMount { get; set; } = null!;

        public BackupScheduleSpecLogBackupTemplateLocalArgs()
        {
        }
        public static new BackupScheduleSpecLogBackupTemplateLocalArgs Empty => new BackupScheduleSpecLogBackupTemplateLocalArgs();
    }
}
