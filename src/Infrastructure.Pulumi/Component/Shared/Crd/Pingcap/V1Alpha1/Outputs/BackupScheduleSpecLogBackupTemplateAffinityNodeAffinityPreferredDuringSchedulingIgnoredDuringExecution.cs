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
    public sealed class BackupScheduleSpecLogBackupTemplateAffinityNodeAffinityPreferredDuringSchedulingIgnoredDuringExecution
    {
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecLogBackupTemplateAffinityNodeAffinityPreferredDuringSchedulingIgnoredDuringExecutionPreference Preference;
        public readonly int Weight;

        [OutputConstructor]
        private BackupScheduleSpecLogBackupTemplateAffinityNodeAffinityPreferredDuringSchedulingIgnoredDuringExecution(
            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecLogBackupTemplateAffinityNodeAffinityPreferredDuringSchedulingIgnoredDuringExecutionPreference preference,

            int weight)
        {
            Preference = preference;
            Weight = weight;
        }
    }
}
