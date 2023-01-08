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
    public sealed class RestoreStatus
    {
        public readonly string CommitTs;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreStatusConditions> Conditions;
        public readonly string Phase;
        public readonly string TimeCompleted;
        public readonly string TimeStarted;

        [OutputConstructor]
        private RestoreStatus(
            string commitTs,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreStatusConditions> conditions,

            string phase,

            string timeCompleted,

            string timeStarted)
        {
            CommitTs = commitTs;
            Conditions = conditions;
            Phase = phase;
            TimeCompleted = timeCompleted;
            TimeStarted = timeStarted;
        }
    }
}