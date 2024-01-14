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
    public sealed class BackupScheduleStatus
    {
        public readonly string AllBackupCleanTime;
        public readonly string LastBackup;
        public readonly string LastBackupTime;
        public readonly string LogBackup;

        [OutputConstructor]
        private BackupScheduleStatus(
            string allBackupCleanTime,

            string lastBackup,

            string lastBackupTime,

            string logBackup)
        {
            AllBackupCleanTime = allBackupCleanTime;
            LastBackup = lastBackup;
            LastBackupTime = lastBackupTime;
            LogBackup = logBackup;
        }
    }
}
