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
    public sealed class BackupStatusLogSubCommandStatuses
    {
        public readonly string Command;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupStatusLogSubCommandStatusesConditions> Conditions;
        public readonly string LogTruncatingUntil;
        public readonly string Phase;
        public readonly string TimeCompleted;
        public readonly string TimeStarted;

        [OutputConstructor]
        private BackupStatusLogSubCommandStatuses(
            string command,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupStatusLogSubCommandStatusesConditions> conditions,

            string logTruncatingUntil,

            string phase,

            string timeCompleted,

            string timeStarted)
        {
            Command = command;
            Conditions = conditions;
            LogTruncatingUntil = logTruncatingUntil;
            Phase = phase;
            TimeCompleted = timeCompleted;
            TimeStarted = timeStarted;
        }
    }
}
