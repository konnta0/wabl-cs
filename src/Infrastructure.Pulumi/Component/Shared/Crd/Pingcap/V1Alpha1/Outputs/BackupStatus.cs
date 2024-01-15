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
    public sealed class BackupStatus
    {
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupStatusBackoffRetryStatus> BackoffRetryStatus;
        public readonly string BackupPath;
        public readonly int BackupSize;
        public readonly string BackupSizeReadable;
        public readonly string CommitTs;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupStatusConditions> Conditions;
        public readonly int IncrementalBackupSize;
        public readonly string IncrementalBackupSizeReadable;
        public readonly string LogCheckpointTs;
        public readonly ImmutableDictionary<string, Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupStatusLogSubCommandStatuses> LogSubCommandStatuses;
        public readonly string LogSuccessTruncateUntil;
        public readonly string Phase;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupStatusProgresses> Progresses;
        public readonly string TimeCompleted;
        public readonly string TimeStarted;
        public readonly string TimeTaken;

        [OutputConstructor]
        private BackupStatus(
            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupStatusBackoffRetryStatus> backoffRetryStatus,

            string backupPath,

            int backupSize,

            string backupSizeReadable,

            string commitTs,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupStatusConditions> conditions,

            int incrementalBackupSize,

            string incrementalBackupSizeReadable,

            string logCheckpointTs,

            ImmutableDictionary<string, Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupStatusLogSubCommandStatuses> logSubCommandStatuses,

            string logSuccessTruncateUntil,

            string phase,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupStatusProgresses> progresses,

            string timeCompleted,

            string timeStarted,

            string timeTaken)
        {
            BackoffRetryStatus = backoffRetryStatus;
            BackupPath = backupPath;
            BackupSize = backupSize;
            BackupSizeReadable = backupSizeReadable;
            CommitTs = commitTs;
            Conditions = conditions;
            IncrementalBackupSize = incrementalBackupSize;
            IncrementalBackupSizeReadable = incrementalBackupSizeReadable;
            LogCheckpointTs = logCheckpointTs;
            LogSubCommandStatuses = logSubCommandStatuses;
            LogSuccessTruncateUntil = logSuccessTruncateUntil;
            Phase = phase;
            Progresses = progresses;
            TimeCompleted = timeCompleted;
            TimeStarted = timeStarted;
            TimeTaken = timeTaken;
        }
    }
}
