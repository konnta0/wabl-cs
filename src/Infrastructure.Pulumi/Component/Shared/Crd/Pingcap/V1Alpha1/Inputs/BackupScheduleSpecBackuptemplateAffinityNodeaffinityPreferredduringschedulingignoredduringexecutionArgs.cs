// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class BackupScheduleSpecBackupTemplateAffinityNodeAffinityPreferredDuringSchedulingIgnoredDuringExecutionArgs : global::Pulumi.ResourceArgs
    {
        [Input("preference", required: true)]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.BackupScheduleSpecBackupTemplateAffinityNodeAffinityPreferredDuringSchedulingIgnoredDuringExecutionPreferenceArgs> Preference { get; set; } = null!;

        [Input("weight", required: true)]
        public Input<int> Weight { get; set; } = null!;

        public BackupScheduleSpecBackupTemplateAffinityNodeAffinityPreferredDuringSchedulingIgnoredDuringExecutionArgs()
        {
        }
        public static new BackupScheduleSpecBackupTemplateAffinityNodeAffinityPreferredDuringSchedulingIgnoredDuringExecutionArgs Empty => new BackupScheduleSpecBackupTemplateAffinityNodeAffinityPreferredDuringSchedulingIgnoredDuringExecutionArgs();
    }
}
